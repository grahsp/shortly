namespace Shortly.Core.ValueObjects;

public sealed record ShortCode
{
    public ShortCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
        
        if (value.Length < MinLength)
            throw new ArgumentException($"Value must be at least {MinLength} characters long.", nameof(value));
        
        if (value.Length > MaxLength)
            throw new ArgumentException($"Value must be at most {MaxLength} characters long.", nameof(value));
        
        if (!value.All(char.IsLetterOrDigit))
            throw new ArgumentException("Value must contain only letters and digits.", nameof(value));
        
        _value = value;
    }

    public const int MinLength = 5;
    public const int MaxLength = 10;

    private readonly string _value;

    public override string ToString() => _value;
}