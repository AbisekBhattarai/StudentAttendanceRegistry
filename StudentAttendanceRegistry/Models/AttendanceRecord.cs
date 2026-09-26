namespace StudentAttendanceRegistry.Models;

// Stores if a student was present or absent in a class on a date
public class AttendanceRecord
{
    private string studentId = "";
    private DateTime attendanceDate = DateTime.Today;

    public int AttendanceId { get; set; }

    public string StudentId
    {
        get { return studentId; }
        set
        {
            if (value == null)
            {
                studentId = "";
            }
            else
            {
                studentId = value.Trim().ToUpper();
            }
        }
    }

    public int ClassId { get; set; }

    // Only keeps the date, not the time
    public DateTime AttendanceDate
    {
        get { return attendanceDate; }
        set { attendanceDate = value.Date; }
    }

    public bool IsPresent { get; set; }

    public string Status
    {
        get { return IsPresent ? "Present" : "Absent"; }
    }
}
