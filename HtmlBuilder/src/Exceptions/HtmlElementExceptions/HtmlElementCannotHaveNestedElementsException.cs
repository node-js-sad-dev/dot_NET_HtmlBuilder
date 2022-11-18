using HtmlBuilder.Elements;

namespace HtmlBuilder.Exceptions.HtmlElementExceptions;

public class HtmlElementCannotHaveNestedElementsException<T> : Exception
    where T : HtmlElement<T>
{
    private HtmlElement<T> _htmlElement;
    
    public HtmlElementCannotHaveNestedElementsException(HtmlElement<T> htmlElement)
    {
        _htmlElement = htmlElement;
    }

    public override string ToString()
    {
        return $"{_htmlElement.TagName} cannot have nested elements";
    }
}