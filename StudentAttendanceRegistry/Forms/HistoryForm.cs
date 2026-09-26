using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

public partial class HistoryForm : Form
{
    private StudentRepository studentRepository = new StudentRepository();
    private ClassRepository classRepository = new ClassRepository();
    private AttendanceRepository attendanceRepository = new AttendanceRepository();
    private AttendanceCalculator calculator = new AttendanceCalculator();

    public HistoryForm()
    {
        InitializeComponent();
    }

    private void HistoryForm_Load(object sender, EventArgs e)
    {
        try
        {
            List<Student> students = studentRepository.GetAll();
            List<ClassGroup> classes = classRepository.GetAll();

            if (students.Count == 0 || classes.Count == 0)
            {
                MessageBox.Show("Please add students and classes first.", "Attendance history");
            }

            // setting the data sources picks the first student and class and loads their history
            cboClass.DataSource = classes;
            cboStudent.DataSource = students;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadHistory();
    }

    private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadHistory();
    }

    // Shows each date the student was marked in the chosen class
    private void LoadHistory()
    {
        dgvHistory.Rows.Clear();
        lblMessage.Text = "";
        lblStats.Text = "";

        Student? student = cboStudent.SelectedItem as Student;
        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (student == null || classGroup == null)
        {
            return;
        }

        try
        {
            List<AttendanceRecord> records = attendanceRepository.GetByStudentAndClass(student.StudentId, classGroup.ClassId);

            foreach (AttendanceRecord record in records)
            {
                dgvHistory.Rows.Add(record.AttendanceDate.ToShortDateString(), record.Status);
            }

            if (records.Count == 0)
            {
                lblMessage.Text = "No attendance recorded for " + student.FullName + " in this class.";
            }
            else
            {
                lblMessage.Text = records.Count + " dates recorded for " + student.FullName + ".";
            }

            ShowStatistics(records);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    // Shows the attended, absent and percentage figures under the message
    private void ShowStatistics(List<AttendanceRecord> records)
    {
        int attended = calculator.CountAttended(records);
        int absent = calculator.CountAbsent(records);
        double percentage = calculator.GetPercentage(records);

        lblStats.Text = "Attended: " + attended + "    Absent: " + absent
            + "    Attendance: " + percentage.ToString("0.0") + "%";
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
    }
}
