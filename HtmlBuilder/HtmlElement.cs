using System.Text;
using HtmlBuilder.Exceptions;

namespace HtmlBuilder;

public abstract class HtmlElement
{
    public readonly bool AllowedToHaveChildren;
    public string TagName { get; set; }
    public Dictionary<string, string?> Properties { get; set; }
    public List<HtmlElement> NestedElements { get; set; }
    protected string[] AllowedProperties { get; set; }

    public HtmlElement(string tagName, bool allowedToHaveChildren)
    {
        TagName = tagName;
        Properties = new Dictionary<string, string?>();
        NestedElements = new List<HtmlElement>();
        AllowedToHaveChildren = allowedToHaveChildren;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"<{TagName} ");

        foreach (var property in Properties)
        {
            if (property.Value != null)
            {
                sb.Append($"{property.Key}=\"{property.Value}\" ");
            }
            else
            {
                sb.Append($"{property.Key} ");
            }
        }

        sb.Append(">\n");

        if (AllowedToHaveChildren)
        {
            foreach (var element in NestedElements)
            {
                sb.Append(element);
            }
        }
        else
        {
            bool textPropertyExist = Properties.TryGetValue("Text", out string? value);

            if (!textPropertyExist) throw new NonValidNestedElementException(this);
            
            sb.Append($"{value}\n");
        }

        sb.Append($"</{TagName}>\n");

        return sb.ToString();
    }
}