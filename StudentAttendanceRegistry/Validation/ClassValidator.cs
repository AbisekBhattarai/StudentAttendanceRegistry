using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Validation;

// Checks class details before they are saved
public class ClassValidator : Validator<ClassGroup>
{
    // Returns an empty string when the class is valid, otherwise the message to show
    public override string Validate(ClassGroup classGroup)
    {
        if (IsBlank(classGroup.ClassCode))
        {
            return "Please enter a class code.";
        }

        if (IsTooLong(classGroup.ClassCode, 20))
        {
            return "Class code can be at most 20 characters.";
        }

        if (classGroup.ClassCode.Contains(' '))
        {
            return "Class code cannot contain spaces, for example ITS203.";
        }

        if (IsBlank(classGroup.ClassName))
        {
            return "Please enter a class name.";
        }

        if (IsTooLong(classGroup.ClassName, 100))
        {
            return "Class name can be at most 100 characters.";
        }

        if (IsBlank(classGroup.Teacher))
        {
            return "Please enter the teacher's name.";
        }

        if (IsTooLong(classGroup.Teacher, 100))
        {
            return "Teacher name can be at most 100 characters.";
        }

        return "";
    }
}
