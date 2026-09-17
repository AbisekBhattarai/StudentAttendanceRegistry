namespace StudentAttendanceRegistry.Models;

// Shows which student is enrolled in which class
public class Enrolment
{
    public int EnrolmentId { get; set; }
    public string StudentId { get; set; } = "";
    public int ClassId { get; set; }
    public DateTime EnrolledOn { get; set; } = DateTime.Today;
}
