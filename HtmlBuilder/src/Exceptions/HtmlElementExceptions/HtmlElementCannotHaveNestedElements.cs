namespace HtmlBuilder.Exceptions.HtmlElementExceptions;

public class HtmlElementCannotHaveNestedElements : Exception
{
    private string _tagName;
    
    public HtmlElementCannotHaveNestedElements(string tagName)
    {
        _tagName = tagName;
    }

    public override string ToString()
    {
        return $"{_tagName} cannot have nested elements";
    }
}