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
    protected List<Property> _properties;
    protected List<T> _nestedElements;

    protected readonly List<PropertyDescription> _allowedProperties;

    public readonly string TagName;

    public List<T> NestedElements
    {
        get => _nestedElements;
        set
        {
            if (!CanHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

            _nestedElements = value;
        }
    }

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
        if (!CanHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

        _nestedElements.Add(nestedElement);
    }

    public void RemoveNestedElement(T nestedElement)
    {
        _nestedElements.Remove(nestedElement);
    }

    public void AddProperty(Property property)
    {
        var canHaveSuchProperty =
            _allowedProperties.Exists(x => x.name == property.Name && x.hasValue == property.HasValue);

        if (!canHaveSuchProperty) throw new HtmlElementCannotHasSuchPropertyException<T>(property, this);
        
        _properties.Add(property);
    }

    public void RemoveProperty(Property property)
    {
        _properties.Remove(property);
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

            if (textPropertyArr.Count == 0) throw new HtmlElementDontHaveTextPropertyException<T>(this);

            var textProperty = textPropertyArr[0];

            sb.Append($"{textProperty.Value}");
        }

        sb.Append($"</{TagName}>\n");

        return sb.ToString();
    }
}