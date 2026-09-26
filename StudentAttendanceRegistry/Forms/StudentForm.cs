using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

// Lists the students; adding and editing happen in StudentEditForm
public partial class StudentForm : Form
{
    private StudentRepository repository = new StudentRepository();

    public StudentForm()
    {
        InitializeComponent();
        Theme.Apply(this, "Add, edit and remove students");
    }

    private void StudentForm_Load(object sender, EventArgs e)
    {
        LoadStudents();
    }

    // Shows the students that match the search box (all of them when it is empty)
    private void LoadStudents()
    {
        try
        {
            List<Student> students = repository.Search(txtSearch.Text.Trim());
            dgvStudents.DataSource = students;
            lblCount.Text = students.Count + " students";

            DataGridViewColumn? fullNameColumn = dgvStudents.Columns["FullName"];
            if (fullNameColumn != null)
            {
                fullNameColumn.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadStudents();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using (StudentEditForm dialog = new StudentEditForm(null))
        {
            if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                LoadStudents();
            }
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        EditSelectedStudent();
    }

    private void dgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // ignore double clicks on the header row
        if (e.RowIndex >= 0)
        {
            EditSelectedStudent();
        }
    }

    private void EditSelectedStudent()
    {
        Student? student = GetSelectedStudent();
        if (student == null)
        {
            MessageBox.Show("Please choose a student from the list first.", "No student selected");
            return;
        }

        using (StudentEditForm dialog = new StudentEditForm(student))
        {
            if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                LoadStudents();
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        Student? student = GetSelectedStudent();
        if (student == null)
        {
            MessageBox.Show("Please choose a student from the list first.", "No student selected");
            return;
        }

        DialogResult answer = MessageBox.Show("Delete " + student.FullName + " (" + student.StudentId + ")? "
            + "Their enrolments and attendance will also be deleted.", "Confirm delete", MessageBoxButtons.YesNo);
        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            repository.Delete(student.StudentId);
            LoadStudents();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private Student? GetSelectedStudent()
    {
        if (dgvStudents.SelectedRows.Count == 0)
        {
            return null;
        }
        return dgvStudents.SelectedRows[0].DataBoundItem as Student;
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
    }
}
