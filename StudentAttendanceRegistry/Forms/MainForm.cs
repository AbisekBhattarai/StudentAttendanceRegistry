namespace StudentAttendanceRegistry.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnManageStudents_Click(object sender, EventArgs e)
    {
        StudentForm form = new StudentForm();
        form.ShowDialog();
    }

    private void btnManageClasses_Click(object sender, EventArgs e)
    {
        ClassForm form = new ClassForm();
        form.ShowDialog();
    }

    private void btnManageEnrolments_Click(object sender, EventArgs e)
    {
        EnrolmentForm form = new EnrolmentForm();
        form.ShowDialog();
    }
}
