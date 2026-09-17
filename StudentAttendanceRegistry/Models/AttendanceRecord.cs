namespace StudentAttendanceRegistry.Models;

// Stores if a student was present or absent in a class on a date
public class AttendanceRecord
{
    public int AttendanceId { get; set; }
    public string StudentId { get; set; } = "";
    public int ClassId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public bool IsPresent { get; set; }

    public string Status
    {
        get { return IsPresent ? "Present" : "Absent"; }
    }
}
