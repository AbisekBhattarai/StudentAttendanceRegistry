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
}
