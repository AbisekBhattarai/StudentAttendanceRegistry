using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

public partial class EnrolmentForm : Form
{
    private ClassRepository classRepository = new ClassRepository();
    private EnrolmentRepository enrolmentRepository = new EnrolmentRepository();

    public EnrolmentForm()
    {
        InitializeComponent();
    }

    private void EnrolmentForm_Load(object sender, EventArgs e)
    {
        try
        {
            List<ClassGroup> classes = classRepository.GetAll();
            if (classes.Count == 0)
            {
                MessageBox.Show("There are no classes yet. Please add a class first.", "No classes");
            }

            // setting the data source picks the first class and runs cboClass_SelectedIndexChanged
            cboClass.DataSource = classes;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadStudentLists();
    }

    // Fills the student drop down and the enrolled grid for the chosen class
    private void LoadStudentLists()
    {
        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null)
        {
            return;
        }

        try
        {
            cboStudent.DataSource = enrolmentRepository.GetStudentsNotInClass(classGroup.ClassId);

            List<Student> enrolled = enrolmentRepository.GetStudentsInClass(classGroup.ClassId);
            dgvEnrolled.DataSource = enrolled;

            DataGridViewColumn? fullNameColumn = dgvEnrolled.Columns["FullName"];
            if (fullNameColumn != null)
            {
                fullNameColumn.Visible = false;
            }

            lblCount.Text = "Students enrolled: " + enrolled.Count;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnEnrol_Click(object sender, EventArgs e)
    {
        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null)
        {
            MessageBox.Show("Please choose a class first.", "No class selected");
            return;
        }

        Student? student = cboStudent.SelectedItem as Student;
        if (student == null)
        {
            MessageBox.Show("Please choose a student to enrol.", "No student selected");
            return;
        }

        try
        {
            if (enrolmentRepository.IsEnrolled(student.StudentId, classGroup.ClassId))
            {
                MessageBox.Show(student.FullName + " is already enrolled in this class.", "Already enrolled");
                return;
            }

            Enrolment enrolment = new Enrolment();
            enrolment.StudentId = student.StudentId;
            enrolment.ClassId = classGroup.ClassId;
            enrolment.EnrolledOn = DateTime.Today;

            enrolmentRepository.Enrol(enrolment);
            LoadStudentLists();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null)
        {
            MessageBox.Show("Please choose a class first.", "No class selected");
            return;
        }

        if (dgvEnrolled.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please choose a student from the enrolled list first.", "No student selected");
            return;
        }

        Student? student = dgvEnrolled.SelectedRows[0].DataBoundItem as Student;
        if (student == null)
        {
            return;
        }

        // removing an enrolment keeps the student's old attendance records
        DialogResult answer = MessageBox.Show("Remove " + student.FullName + " from " + classGroup.ClassCode + "?",
            "Confirm remove", MessageBoxButtons.YesNo);
        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            enrolmentRepository.Unenrol(student.StudentId, classGroup.ClassId);
            LoadStudentLists();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
    }
}
