using System.ComponentModel;

namespace StudentAttendanceRegistry.Models;

// Stores the details of one student
public class Student
{
    private string studentId = "";
    private string firstName = "";
    private string lastName = "";
    private string email = "";

    // Saves the id in capitals
    [DisplayName("Student ID")]
    public string StudentId
    {
        get { return studentId; }
        set { studentId = Clean(value).ToUpper(); }
    }

    [DisplayName("First Name")]
    public string FirstName
    {
        get { return firstName; }
        set { firstName = Clean(value); }
    }

    [DisplayName("Last Name")]
    public string LastName
    {
        get { return lastName; }
        set { lastName = Clean(value); }
    }

    public string Email
    {
        get { return email; }
        set { email = Clean(value); }
    }

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public override string ToString()
    {
        return StudentId + " - " + FullName;
    }

    // Removes extra spaces
    private string Clean(string? value)
    {
        if (value == null)
        {
            return "";
        }
        return value.Trim();
    }
}
