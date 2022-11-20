using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.BodyElements.WithNestedElements;

public class Div : BodyElement
{
    public Div() : base("div", true, true, new List<PropertyDescription>()
    {
        new PropertyDescription("style", true)
    })
    {
    }
}