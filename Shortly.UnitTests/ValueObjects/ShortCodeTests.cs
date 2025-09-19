using Shortly.Core.ValueObjects;

namespace Shortly.UnitTests.ValueObjects;

public class ShortCodeTests
{
    private const int CodeLength = (ShortCode.MinLength + ShortCode.MaxLength) / 2;
    
    [Fact]
    public void ShortCode_Succeeds_OnValidLength()
    {
        var input = new string('a', CodeLength);
        var shortCode = new ShortCode(input);
        
        Assert.Equal(input, shortCode.ToString());
    }
    
    [Fact]
    public void ShortCode_Succeeds_WithMinLength()
    {
        var input = new string('a', ShortCode.MinLength);
        var shortCode = new ShortCode(input);
        
        Assert.Equal(input, shortCode.ToString());
    }
    
    [Fact]
    public void ShortCode_Succeeds_WithMaxLength()
    {
        var input = new string('a', ShortCode.MaxLength);
        var shortCode = new ShortCode(input);

        Assert.Equal(input, shortCode.ToString());
    }

    [Fact]
    public void ShortCode_Allows_Letters()
    {
        var input = new string('a', ShortCode.MaxLength);
        var shortCode = new ShortCode(input);

        Assert.Equal(input, shortCode.ToString());
    }

    [Fact]
    public void ShortCode_Allows_Numbers()
    {
        var input = new string('5', ShortCode.MaxLength);
        var shortCode = new ShortCode(input);

        Assert.Equal(input, shortCode.ToString());
    }

    [Fact]
    public void ShortCode_ShouldBe_CaseSensitive()
    {
        var input = new string('a', CodeLength);
        var upperCaseCode = new ShortCode(input.ToUpper());
        var lowerCaseCode = new ShortCode(input.ToLower());
        
        Assert.NotEqual(upperCaseCode, lowerCaseCode);
    }

    [Fact]
    public void ShortCode_Throws_OnNull()
    {
        Assert.Throws<ArgumentException>(() => new ShortCode(null!));
    }
    
    [Fact]
    public void ShortCode_Throws_OnEmpty()
    {
        var input = string.Empty;
        Assert.Throws<ArgumentException>(() => new ShortCode(input));
    }

    [Fact]
    public void ShortCode_Throws_OnWhitespace()
    {
        var input = new string(' ', CodeLength);
        Assert.Throws<ArgumentException>(() => new ShortCode(input));
    }

    [Fact]
    public void ShortCode_Throws_OnSpecialCharacters()
    {
        var input = new string('$', CodeLength);
        Assert.Throws<ArgumentException>(() => new ShortCode(input));
    }
    
    [Fact]
    public void ShortCode_Throws_OnTooShort()
    {
        var input = new string('a', ShortCode.MinLength - 1);
        Assert.Throws<ArgumentException>(() => new ShortCode(input));
    }

    [Fact]
    public void ShortCode_Throws_OnTooLong()
    {
        var input = new string('a', ShortCode.MaxLength + 1);
        Assert.Throws<ArgumentException>(() => new ShortCode(input));
    }
}