using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Validation;

// Checks class details before they are saved
public class ClassValidator
{
    // Returns an empty string when the class is valid, otherwise the message to show
    public string Validate(ClassGroup classGroup)
    {
        if (string.IsNullOrWhiteSpace(classGroup.ClassCode))
        {
            return "Please enter a class code.";
        }

        if (classGroup.ClassCode.Length > 20)
        {
            return "Class code can be at most 20 characters.";
        }

        if (classGroup.ClassCode.Contains(' '))
        {
            return "Class code cannot contain spaces, for example ITS203.";
        }

        if (string.IsNullOrWhiteSpace(classGroup.ClassName))
        {
            return "Please enter a class name.";
        }

        if (classGroup.ClassName.Length > 100)
        {
            return "Class name can be at most 100 characters.";
        }

        if (string.IsNullOrWhiteSpace(classGroup.Teacher))
        {
            return "Please enter the teacher's name.";
        }

        if (classGroup.Teacher.Length > 100)
        {
            return "Teacher name can be at most 100 characters.";
        }

        return "";
    }
}
