namespace StudentAttendanceRegistry.Models;

// Stores the details of one student
public class Student
{
    public string StudentId { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public override string ToString()
    {
        return StudentId + " - " + FullName;
    }
}
