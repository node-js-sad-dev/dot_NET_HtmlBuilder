namespace HtmlBuilder.Elements.P;

public class P : HtmlElement
{
    public P() : base("p", false)
    {
        AllowedProperties = new[] { "Text" };
    }
}