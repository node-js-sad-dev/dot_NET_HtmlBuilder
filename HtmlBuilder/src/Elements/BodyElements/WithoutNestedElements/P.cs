using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.BodyElements.WithoutNestedElements;

public class P : BodyElement
{
    public P() : base("p", true, false, new List<PropertyDescription>()
    {
        new PropertyDescription("Text", true)
    })
    {
    }
}