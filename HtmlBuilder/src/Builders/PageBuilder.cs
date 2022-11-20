using System.Text;
using HtmlBuilder.Elements.BodyElements;
using HtmlBuilder.Elements.HeaderElements;

namespace HtmlBuilder.Builders;

/*
    * This builder will be used only for getting ready html file as string or as a file
*/
public class PageBuilder
{
    private readonly HeaderElement? _headerElement;
    private readonly BodyElement _bodyElement;

    public PageBuilder(HeaderElement? headerElement, BodyElement bodyElement)
    {
        _headerElement = headerElement;
        _bodyElement = bodyElement;
    }

    public PageBuilder(BodyElement bodyElement)
    {
        _bodyElement = bodyElement;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append("<!DOCTYPE html>\n")
            .Append("<html>\n");

        sb.Append("<head>\n");

        if (_headerElement != null)
        {
            sb.Append(_headerElement);
        }

        sb.Append("</head>\n")
            .Append("<body>\n")
            .Append(_bodyElement)
            .Append("</body>\n")
            .Append("</html>");

        return sb.ToString();
    }

    public void GenerateHtmlFile(string path)
    {
        var html = ToString();
        
        File.WriteAllText(path, html);
    }
}