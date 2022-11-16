namespace HtmlBuilder.Exceptions.HtmlElementExceptions;

public class HtmlElementDontHaveTextPropertyException : Exception
{
    private string TagName;

    public HtmlElementDontHaveTextPropertyException(string tagName)
    {
        TagName = tagName;
    }

    public override string ToString()
    {
        return $"{TagName} don`t have text property and is double tag";
    }
}