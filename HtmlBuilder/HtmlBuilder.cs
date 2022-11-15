namespace HtmlBuilder;

public sealed class HtmlBuilder
{
    public static implicit operator HtmlElement(HtmlBuilder hb) => hb._htmlElement;
    public static explicit operator HtmlBuilder(HtmlElement he) => new(he);
    
    private readonly HtmlElement _htmlElement;

    public HtmlBuilder(HtmlElement htmlElement)
    {
        _htmlElement = htmlElement;
    }
    
    public override string ToString()
    {
        return _htmlElement.ToString();
    }
}