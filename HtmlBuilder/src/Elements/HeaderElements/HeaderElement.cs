using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.HeaderElements;

public abstract class HeaderElement : HtmlElement<HeaderElement>
{
    protected HeaderElement(string tagName, bool isDouble, bool canHaveNestedElements,
        List<PropertyDescription> allowedProperties) : base(tagName, isDouble, canHaveNestedElements, allowedProperties)
    {
    }
}