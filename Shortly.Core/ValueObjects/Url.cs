namespace Shortly.Core.ValueObjects;

public sealed record Url
{
    public Url(string url)
    {
        if (!Uri.TryCreate(url, UriKind.Absolute, out var parsed))
            throw new ArgumentException("Invalid URL", nameof(url));
        
        if (parsed.Scheme != "http" && parsed.Scheme != "https")
            throw new ArgumentException("Only HTTP/HTTPS are supported.", nameof(url));
            
        _uri = parsed;
    }

    private readonly Uri _uri;
    
    public override string ToString()
        => _uri.ToString();
}