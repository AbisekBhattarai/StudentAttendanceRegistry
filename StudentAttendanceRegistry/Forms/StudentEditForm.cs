using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;
using StudentAttendanceRegistry.Validation;

namespace StudentAttendanceRegistry.Forms;

// Small window used to add a new student or edit an existing one
public partial class StudentEditForm : Form
{
    private StudentRepository repository = new StudentRepository();
    private StudentValidator validator = new StudentValidator();

    // true when adding, false when editing
    private bool isNew;

    // Pass null to add a new student, or a student to edit
    public StudentEditForm(Student? student)
    {
        InitializeComponent();
        Theme.ApplyDialog(this);
        lblTitle.ForeColor = Theme.DarkText;
        lblSubtitle.ForeColor = Theme.MutedText;
        lblError.ForeColor = Theme.Danger;

        toolTip.SetToolTip(txtStudentId, "The letter S followed by 7 numbers");
        toolTip.SetToolTip(txtEmail, "Can be left empty");
        toolTip.SetToolTip(btnSave, "Save the student (Enter)");
        toolTip.SetToolTip(btnCancel, "Close without saving (Esc)");

        if (student == null)
        {
            isNew = true;
            lblTitle.Text = "Add Student";
        }
        else
        {
            isNew = false;
            lblTitle.Text = "Edit Student";
            lblSubtitle.Text = "The student ID can't be changed.";
            txtStudentId.Text = student.StudentId;
            txtStudentId.ReadOnly = true;
            txtFirstName.Text = student.FirstName;
            txtLastName.Text = student.LastName;
            txtEmail.Text = student.Email;

            // start typing in the first box that can be changed
            ActiveControl = txtFirstName;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Student student = new Student();
        student.StudentId = txtStudentId.Text;
        student.FirstName = txtFirstName.Text;
        student.LastName = txtLastName.Text;
        student.Email = txtEmail.Text;

        // show problems inside the window instead of a pop-up
        string message = validator.Validate(student);
        if (message != "")
        {
            lblError.Text = message;
            return;
        }

        try
        {
            if (isNew)
            {
                if (repository.Exists(student.StudentId))
                {
                    lblError.Text = "A student with that ID already exists.";
                    return;
                }
                repository.Add(student);
            }
            else
            {
                repository.Update(student);
            }

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
