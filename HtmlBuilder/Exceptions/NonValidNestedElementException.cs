namespace HtmlBuilder.Exceptions;

public sealed class NonValidNestedElementException : Exception
{
    private readonly HtmlElement _elementToCauseException;

    public NonValidNestedElementException(HtmlElement htmlElement)
    {
        _elementToCauseException = htmlElement;
    }

    public override string ToString()
    {
        return $"{_elementToCauseException.TagName} not allowed to have child elements";
    }
}