using HtmlBuilder.Elements.HeaderElements;

namespace HtmlBuilder.Builders;

public sealed class HeaderHtmlElementBuilder : HtmlElementBuilder<HeaderElement>
{
    public static implicit operator HeaderElement(HeaderHtmlElementBuilder hb) => hb.HtmlElement;
    public static explicit operator HeaderHtmlElementBuilder(HeaderElement he) => new(he);
    
    public HeaderHtmlElementBuilder(HeaderElement headerElement) : base(headerElement)
    {
    }
}