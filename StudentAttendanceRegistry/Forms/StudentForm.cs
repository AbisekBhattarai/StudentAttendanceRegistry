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
            if (students.Count == 1)
            {
                lblCount.Text = "1 student";
            }
            else
            {
                lblCount.Text = students.Count + " students";
            }

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
            MessageBox.Show("Please click a student in the list, then press Edit.", "No student selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            MessageBox.Show("Please click a student in the list, then press Delete.", "No student selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // No is the default button so pressing Enter by mistake does not delete anything
        DialogResult answer = MessageBox.Show("Delete " + student.FullName + " (" + student.StudentId + ")? "
            + "Their enrolments and attendance will also be deleted.", "Confirm delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
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
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
