using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.BodyElements.WithNestedElements;

public class P : BodyElement
{
    public P() : base("p", true, true, new List<PropertyDescription>()
    {
        new("Text", true)
    })
    {
    }
}