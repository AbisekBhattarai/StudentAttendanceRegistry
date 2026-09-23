using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Services;

// Calculates attended, absent and percentage figures for a student
public class AttendanceCalculator
{
    // Counts the records marked as present
    public int CountAttended(List<AttendanceRecord> records)
    {
        int attended = 0;
        foreach (AttendanceRecord record in records)
        {
            if (record.IsPresent)
            {
                attended++;
            }
        }
        return attended;
    }

    // Counts the records marked as absent
    public int CountAbsent(List<AttendanceRecord> records)
    {
        return records.Count - CountAttended(records);
    }

    // Returns the attendance percentage, or 0 when nothing has been recorded yet
    public double GetPercentage(List<AttendanceRecord> records)
    {
        if (records.Count == 0)
        {
            return 0;
        }

        double percentage = (double)CountAttended(records) / records.Count * 100;
        return Math.Round(percentage, 1);
    }
}
