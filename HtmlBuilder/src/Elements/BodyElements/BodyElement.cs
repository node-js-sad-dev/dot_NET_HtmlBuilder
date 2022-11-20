using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.BodyElements;

public abstract class BodyElement : HtmlElement<BodyElement>
{
    protected BodyElement(string tagName, bool isDouble, bool canHaveNestedElements,
        List<PropertyDescription> allowedProperties) : base(tagName, isDouble, canHaveNestedElements, allowedProperties)
    {
    }
}