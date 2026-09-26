using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Validation;

// Checks student details before they are saved
public class StudentValidator : Validator<Student>
{
    // Returns an empty string when the student is valid, otherwise the message to show
    public override string Validate(Student student)
    {
        if (IsBlank(student.StudentId))
        {
            return "Please enter a student id.";
        }

        if (!IsValidStudentId(student.StudentId))
        {
            return "Student id must be the letter S followed by 7 numbers, for example S2500187.";
        }

        if (IsBlank(student.FirstName))
        {
            return "Please enter a first name.";
        }

        if (IsBlank(student.LastName))
        {
            return "Please enter a last name.";
        }

        if (student.Email != "" && !IsValidEmail(student.Email))
        {
            return "Please enter a valid email address or leave it empty.";
        }

        return "";
    }

    public bool IsValidStudentId(string studentId)
    {
        studentId = studentId.Trim();

        if (studentId.Length != 8)
        {
            return false;
        }

        if (char.ToUpper(studentId[0]) != 'S')
        {
            return false;
        }

        for (int i = 1; i < studentId.Length; i++)
        {
            if (!char.IsDigit(studentId[i]))
            {
                return false;
            }
        }

        return true;
    }

    public bool IsValidEmail(string email)
    {
        email = email.Trim();

        int atPosition = email.IndexOf('@');
        int dotPosition = email.LastIndexOf('.');

        // there must be text before the @, between the @ and the dot, and after the dot
        if (atPosition < 1)
        {
            return false;
        }

        if (dotPosition < atPosition + 2)
        {
            return false;
        }

        if (dotPosition == email.Length - 1)
        {
            return false;
        }

        if (email.Contains(' '))
        {
            return false;
        }

        return true;
    }
}
