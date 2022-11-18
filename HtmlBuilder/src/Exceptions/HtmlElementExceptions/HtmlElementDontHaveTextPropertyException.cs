using HtmlBuilder.Elements;

namespace HtmlBuilder.Exceptions.HtmlElementExceptions;

public class HtmlElementDontHaveTextPropertyException<T> : Exception
    where T : HtmlElement<T>
{
    private readonly HtmlElement<T> _htmlElement;

    public HtmlElementDontHaveTextPropertyException(HtmlElement<T> htmlElement)
    {
        _htmlElement = htmlElement;
    }

    public override string ToString()
    {
        return $"{_htmlElement.TagName} don`t have text property and is double tag";
    }
}