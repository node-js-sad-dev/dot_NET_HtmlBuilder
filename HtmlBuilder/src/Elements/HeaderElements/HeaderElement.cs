namespace HtmlBuilder.Elements.HeaderElements;

public abstract class HeaderElement : HtmlElement<HeaderElement>
{
    protected HeaderElement(string tagName, bool isDouble, bool canHaveNestedElements) : base(tagName, isDouble, canHaveNestedElements)
    {
    }
}