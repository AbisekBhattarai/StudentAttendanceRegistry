namespace StudentAttendanceRegistry.Validation;

// Base class for all validators
public abstract class Validator<T>
{
    // Returns "" if valid, otherwise an error message
    public abstract string Validate(T item);

    // Checks for empty text
    protected bool IsBlank(string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }

    // Checks the text length
    protected bool IsTooLong(string text, int maxLength)
    {
        return text.Length > maxLength;
    }
}
