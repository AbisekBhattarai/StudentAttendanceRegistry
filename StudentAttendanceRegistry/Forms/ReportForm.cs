using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

public partial class ReportForm : Form
{
    private ClassRepository classRepository = new ClassRepository();
    private EnrolmentRepository enrolmentRepository = new EnrolmentRepository();
    private AttendanceRepository attendanceRepository = new AttendanceRepository();
    private AttendanceCalculator calculator = new AttendanceCalculator();

    // students under this percentage are highlighted in the report
    private const double MinimumPercentage = 75;

    public ReportForm()
    {
        InitializeComponent();
    }

    private void ReportForm_Load(object sender, EventArgs e)
    {
        try
        {
            List<ClassGroup> classes = classRepository.GetAll();
            if (classes.Count == 0)
            {
                MessageBox.Show("Please add a class first.", "Attendance report");
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

                // show a dash when the student has not been marked yet
                string percentage = "-";
                if (records.Count > 0)
                {
                    percentage = calculator.GetPercentage(records).ToString("0.0") + "%";
                }

                int rowIndex = dgvReport.Rows.Add(student.StudentId, student.FullName, attended, absent, percentage);

                // colour the row red when the student is below 75%
                if (records.Count > 0 && calculator.GetPercentage(records) < MinimumPercentage)
                {
                    dgvReport.Rows[rowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                    dgvReport.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    belowCount++;
                }
            }

            lblMessage.Text = students.Count + " students enrolled in " + classGroup.ClassCode + ", "
                + belowCount + " below 75% attendance.";
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show("Could not reach the database. Check that MySQL is running in XAMPP."
            + Environment.NewLine + Environment.NewLine + ex.Message, "Database error");
    }
}
