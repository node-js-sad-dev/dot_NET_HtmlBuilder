using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements.HeaderElements.WithoutNestedElements;

public class Meta : HeaderElement
{
    public Meta() : base("meta", false, false, new List<PropertyDescription>()
    {
        new("charset", true),
        new("name", true),
        new("content", true)
    }) {}
}