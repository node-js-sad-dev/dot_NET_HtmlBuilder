using HtmlBuilder.Elements;
using HtmlBuilder.Properties;

namespace HtmlBuilder.Exceptions.HtmlElementExceptions;

public class HtmlElementCannotHasSuchPropertyException<T> : Exception
    where T : HtmlElement<T>
{
    private readonly Property _property;
    private readonly HtmlElement<T> _htmlElement;

    public HtmlElementCannotHasSuchPropertyException(Property property, HtmlElement<T> htmlElement)
    {
        _property = property;
        _htmlElement = htmlElement;
    }

    public override string ToString()
    {
        return $"{_htmlElement.TagName} cannot have property {_property.Name}";
    }
}