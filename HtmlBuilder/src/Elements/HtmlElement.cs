using System.Text;
using System.Linq;
using HtmlBuilder.Exceptions.HtmlElementExceptions;
using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements;

public abstract class HtmlElement<T>
    where T : HtmlElement<T>
{
    public readonly bool IsDouble;
    public readonly bool CanHaveNestedElements;
    private List<Property> _properties;
    private List<T> _nestedElements;

    public readonly string TagName;

    protected HtmlElement(string tagName, bool isDouble, bool canHaveNestedElements)
    {
        TagName = tagName;
        IsDouble = isDouble;
        CanHaveNestedElements = canHaveNestedElements;
        _properties = new List<Property>();
        _nestedElements = new List<T>();
    }

    public void AddNestedElement(T nestedElement)
    {
        _nestedElements.Add(nestedElement);
    }

    public void RemoveNestedElement(T nestedElement)
    {
        _nestedElements.Remove(nestedElement);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"<{TagName} ");

        foreach (var property in _properties)
        {
            sb.Append(property.HasValue
                ? $"{property.Name}=\"{property.Value}\" "
                : $"{property.Name} ");
        }

        sb.Append(">\n");

        if (!IsDouble) return sb.ToString();
        
        if (CanHaveNestedElements)
        {
            foreach (var element in _nestedElements)
            {
                sb.Append(element);
            }
        }
        else
        {
            var textPropertyArr = _properties.Where(x => x.Name == "Text").ToList();

            if (textPropertyArr.Count == 0) throw new HtmlElementDontHaveTextPropertyException(TagName);
        }

        sb.Append($"</{TagName}>\n");
        
        return sb.ToString();
    }
}