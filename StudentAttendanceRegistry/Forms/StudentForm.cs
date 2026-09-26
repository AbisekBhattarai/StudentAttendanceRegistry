using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;
using StudentAttendanceRegistry.Validation;

namespace StudentAttendanceRegistry.Forms;

public partial class StudentForm : Form
{
    private StudentRepository repository = new StudentRepository();
    private StudentValidator validator = new StudentValidator();

    public StudentForm()
    {
        InitializeComponent();
    }

    private void StudentForm_Load(object sender, EventArgs e)
    {
        LoadStudents();
    }

    private void LoadStudents()
    {
        try
        {
            ShowStudents(repository.GetAll());
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowStudents(List<Student> students)
    {
        dgvStudents.DataSource = students;

        DataGridViewColumn? fullNameColumn = dgvStudents.Columns["FullName"];
        if (fullNameColumn != null)
        {
            fullNameColumn.Visible = false;
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Student student = ReadFormFields();

        string message = validator.Validate(student);
        if (message != "")
        {
            MessageBox.Show(message, "Please check the details");
            return;
        }

        try
        {
            if (repository.Exists(student.StudentId))
            {
                MessageBox.Show("A student with that id already exists.", "Duplicate student");
                return;
            }

            repository.Add(student);
            LoadStudents();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        Student student = ReadFormFields();

        string message = validator.Validate(student);
        if (message != "")
        {
            MessageBox.Show(message, "Please check the details");
            return;
        }

        try
        {
            if (!repository.Exists(student.StudentId))
            {
                MessageBox.Show("There is no student with that id.", "Student not found");
                return;
            }

            repository.Update(student);
            LoadStudents();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        string studentId = txtStudentId.Text.Trim();

        if (studentId == "")
        {
            MessageBox.Show("Please choose a student from the list first.", "No student selected");
            return;
        }

        DialogResult answer = MessageBox.Show("Delete student " + studentId + "?", "Confirm delete",
            MessageBoxButtons.YesNo);
        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            repository.Delete(studentId);
            LoadStudents();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ShowStudents(repository.Search(txtSearch.Text.Trim()));
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        LoadStudents();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    // Copies the details of the row the user clicked into the text boxes
    private void dgvStudents_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvStudents.SelectedRows.Count == 0)
        {
            return;
        }

        Student? student = dgvStudents.SelectedRows[0].DataBoundItem as Student;
        if (student == null)
        {
            return;
        }

        txtStudentId.Text = student.StudentId;
        txtFirstName.Text = student.FirstName;
        txtLastName.Text = student.LastName;
        txtEmail.Text = student.Email;
    }

    private Student ReadFormFields()
    {
        Student student = new Student();
        student.StudentId = txtStudentId.Text.Trim().ToUpper();
        student.FirstName = txtFirstName.Text.Trim();
        student.LastName = txtLastName.Text.Trim();
        student.Email = txtEmail.Text.Trim();
        return student;
    }

    private void ClearFields()
    {
        txtStudentId.Text = "";
        txtFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtStudentId.Focus();
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
    }
}
