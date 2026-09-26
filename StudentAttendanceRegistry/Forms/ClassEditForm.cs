using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;
using StudentAttendanceRegistry.Validation;

namespace StudentAttendanceRegistry.Forms;

// Small window used to add a new class or edit an existing one
public partial class ClassEditForm : Form
{
    private ClassRepository repository = new ClassRepository();
    private ClassValidator validator = new ClassValidator();

    // 0 when adding a new class
    private int classId = 0;

    // Pass null to add a new class, or a class to edit
    public ClassEditForm(ClassGroup? classGroup)
    {
        InitializeComponent();
        Theme.ApplyDialog(this);
        lblTitle.ForeColor = Theme.DarkText;
        lblSubtitle.ForeColor = Theme.MutedText;
        lblError.ForeColor = Theme.Danger;

        if (classGroup != null)
        {
            classId = classGroup.ClassId;
            lblTitle.Text = "Edit Class";
            lblSubtitle.Text = "Change the details and press Save.";
            txtClassCode.Text = classGroup.ClassCode;
            txtClassName.Text = classGroup.ClassName;
            txtTeacher.Text = classGroup.Teacher;
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        ClassGroup classGroup = new ClassGroup();
        classGroup.ClassId = classId;
        classGroup.ClassCode = txtClassCode.Text.Trim().ToUpper();
        classGroup.ClassName = txtClassName.Text.Trim();
        classGroup.Teacher = txtTeacher.Text.Trim();

        // show problems inside the window instead of a pop-up
        string message = validator.Validate(classGroup);
        if (message != "")
        {
            lblError.Text = message;
            return;
        }

        try
        {
            if (repository.CodeExists(classGroup.ClassCode, classId))
            {
                lblError.Text = "Another class already uses that code.";
                return;
            }

            if (classId == 0)
            {
                repository.Add(classGroup);
            }
            else
            {
                repository.Update(classGroup);
            }

            DialogResult = DialogResult.OK;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
        }
    }
}
