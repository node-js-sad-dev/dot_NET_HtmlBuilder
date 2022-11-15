namespace HtmlBuilder.Exceptions;

public sealed class NonValidHtmlPropertyException : Exception
{
    private readonly string _propertyCausedException;

    public NonValidHtmlPropertyException(string propertyCausedException)
    {
        _propertyCausedException = propertyCausedException;
    }

    public override string ToString()
    {
        return $"Because of {_propertyCausedException} property html code is invalid";
    }
}