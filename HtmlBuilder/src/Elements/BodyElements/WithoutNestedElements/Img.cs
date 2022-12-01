using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.BodyElements.WithoutNestedElements;

public class Img : BodyElement
{
    public Img() : base("img", false, false, new List<PropertyDescription>()
    {
        new("url", true)
    })
    {
    }
}