using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Validation;

// Checks attendance entries before they are saved
public class AttendanceValidator : Validator<AttendanceRecord>
{
    // Returns an empty string when the date is fine, otherwise the message to show
    public string ValidateDate(DateTime date)
    {
        if (date.Date > DateTime.Today)
        {
            return "Attendance cannot be saved for a future date.";
        }

        return "";
    }

    // Checks one attendance record
    public override string Validate(AttendanceRecord record)
    {
        if (IsBlank(record.StudentId))
        {
            return "One of the rows has no student id.";
        }

        if (record.ClassId <= 0)
        {
            return "Please choose a class.";
        }

        return ValidateDate(record.AttendanceDate);
    }

    // Returns an empty string when every record is valid, otherwise the message to show
    public string ValidateAll(List<AttendanceRecord> records)
    {
        if (records.Count == 0)
        {
            return "There are no students to save attendance for.";
        }

        foreach (AttendanceRecord record in records)
        {
            string message = Validate(record);
            if (message != "")
            {
                return message;
            }
        }

        return "";
    }
}
