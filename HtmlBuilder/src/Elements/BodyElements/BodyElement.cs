namespace HtmlBuilder.Elements.BodyElements;

public abstract class BodyElement : HtmlElement<BodyElement>
{
    protected BodyElement(string tagName, bool isDouble, bool canHaveNestedElements) : base(tagName, isDouble, canHaveNestedElements)
    {
    }
}