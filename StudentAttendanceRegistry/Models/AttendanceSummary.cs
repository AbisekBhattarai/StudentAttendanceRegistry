using System.ComponentModel;

namespace StudentAttendanceRegistry.Models;

// Attendance totals for one student in one class, used on the dashboard
public class AttendanceSummary
{
    [DisplayName("Student ID")]
    public string StudentId { get; set; } = "";

    [DisplayName("Student")]
    public string StudentName { get; set; } = "";

    [DisplayName("Class")]
    public string ClassCode { get; set; } = "";

    public int Attended { get; set; }

    [DisplayName("Sessions")]
    public int Total { get; set; }

    [DisplayName("Attendance %")]
    public double Percentage
    {
        get
        {
            if (Total == 0)
            {
                return 0;
            }
            return Math.Round((double)Attended / Total * 100, 1);
        }
    }
}
