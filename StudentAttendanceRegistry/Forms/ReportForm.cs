using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

// Attendance summary for every student in a class
public partial class ReportForm : Form
{
    private ClassRepository classRepository = new ClassRepository();
    private EnrolmentRepository enrolmentRepository = new EnrolmentRepository();
    private AttendanceRepository attendanceRepository = new AttendanceRepository();
    private AttendanceCalculator calculator = new AttendanceCalculator();

    public ReportForm()
    {
        InitializeComponent();
        Theme.Apply(this, "Attendance totals for every student in a class");

        toolTip.SetToolTip(cboClass, "The class to show the report for");
        toolTip.SetToolTip(lblKey, "These students are under the minimum attendance");
    }

    private void ReportForm_Load(object sender, EventArgs e)
    {
        try
        {
            List<ClassGroup> classes = classRepository.GetAll();
            if (classes.Count == 0)
            {
                MessageBox.Show("There are no classes yet. Please add a class on the Classes page first.", "Attendance report",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // setting the data source picks the first class and loads its report
            cboClass.DataSource = classes;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadReport();
    }

    // Shows one row per enrolled student with their attendance figures
    private void LoadReport()
    {
        dgvReport.Rows.Clear();
        lblMessage.Text = "";

        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null)
        {
            return;
        }

        try
        {
            List<Student> students = enrolmentRepository.GetStudentsInClass(classGroup.ClassId);
            if (students.Count == 0)
            {
                lblMessage.Text = "No students are enrolled in " + classGroup.ClassCode + ".";
                return;
            }

            int belowCount = 0;

            foreach (Student student in students)
            {
                List<AttendanceRecord> records = attendanceRepository.GetByStudentAndClass(student.StudentId, classGroup.ClassId);
                int attended = calculator.CountAttended(records);
                int absent = calculator.CountAbsent(records);
                double percentage = calculator.GetPercentage(records);

                // show a dash when the student has not been marked yet
                string percentageText = "-";
                if (records.Count > 0)
                {
                    percentageText = percentage.ToString("0.0") + "%";
                }

                int rowIndex = dgvReport.Rows.Add(student.StudentId, student.FullName, attended, absent, percentageText);

                // colour the row red when the student is below the minimum
                if (records.Count > 0 && percentage < AttendanceCalculator.MinimumPercentage)
                {
                    dgvReport.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    dgvReport.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    belowCount++;
                }
            }

            lblMessage.Text = students.Count + " enrolled in " + classGroup.ClassCode + ", "
                + belowCount + " below " + AttendanceCalculator.MinimumPercentage + "% attendance.";
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
