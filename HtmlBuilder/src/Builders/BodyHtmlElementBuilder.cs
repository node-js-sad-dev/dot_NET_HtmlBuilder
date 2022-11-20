using HtmlBuilder.Elements.BodyElements;

namespace HtmlBuilder.Builders;

public class BodyHtmlElementBuilder : HtmlElementBuilder<BodyElement>
{
    public static implicit operator BodyElement(BodyHtmlElementBuilder bb) => bb.HtmlElement;
    public static explicit operator BodyHtmlElementBuilder(BodyElement be) => new(be);
    
    public BodyHtmlElementBuilder(BodyElement htmlElement) : base(htmlElement)
    {
    }
}