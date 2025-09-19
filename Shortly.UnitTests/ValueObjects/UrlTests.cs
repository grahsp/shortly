using Shortly.Core.ValueObjects;

namespace Shortly.UnitTests.ValueObjects;

public class UrlTests
{
    [Fact]
    public void Url_Succeeds_OnValidInput()
    {
        const string input = "https://www.google.com";
        
        var url = new Url(input);
        
        Assert.Equal(input, url.ToString());
    }

    [Fact]
    public void Url_Throws_OnMissingScheme()
    {
        Assert.Throws<ArgumentException>(() => new Url("www.google.com"));
    }
    
    [Fact]
    public void Url_Throws_OnInvalidScheme()
    {
        Assert.Throws<ArgumentException>(() => new Url("ftp://www.google.com"));
    }
}