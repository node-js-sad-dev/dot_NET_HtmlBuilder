using System.Text;
using System.Linq;
using HtmlBuilder.Exceptions.HtmlElementExceptions;
using HtmlBuilder.Properties;

namespace HtmlBuilder.Elements;

public abstract class HtmlElement<T>
    where T : HtmlElement<T>
{
    private readonly bool _isDouble;
    private readonly bool _canHaveNestedElements;
    private List<Property> _properties;
    private List<T> _nestedElements;

    private readonly List<PropertyDescription> _allowedProperties;

    public readonly string TagName;

    protected HtmlElement(string tagName, bool isDouble, bool canHaveNestedElements,
        List<PropertyDescription> allowedProperties)
    {
        TagName = tagName;
        _isDouble = isDouble;
        _canHaveNestedElements = canHaveNestedElements;
        _properties = new List<Property>();
        _nestedElements = new List<T>();
        _allowedProperties = allowedProperties;
    }

    public void AddNestedElement(T nestedElement)
    {
        if (!_canHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

        _nestedElements.Add(nestedElement);
    }

    public void RemoveNestedElement(T nestedElement)
    {
        if (!_canHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

        _nestedElements.Remove(nestedElement);
    }

    public void SetNestedElements(List<T> nestedElements)
    {
        if (!_canHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

        _nestedElements = nestedElements;
    }

    public void ClearNestedElements()
    {
        if (!_canHaveNestedElements) throw new HtmlElementCannotHaveNestedElementsException<T>(this);

        _nestedElements.Clear();
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

    public void SetProperties(List<Property> properties)
    {
        foreach (var property in properties)
        {
            var canHaveSuchProperty =
                _allowedProperties.Exists(x => x.name == property.Name && x.hasValue == property.HasValue);
            
            if (!canHaveSuchProperty) throw new HtmlElementCannotHasSuchPropertyException<T>(property, this);
        }
        
        _properties = properties;
    }

    public void ClearProperties()
    {
        _properties.Clear();
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append($"<{TagName} ");

        foreach (var property in _properties)
        {
            if (property.Name == "Text") continue;
            
            sb.Append(property.HasValue
                ? $"{property.Name}=\"{property.Value}\" "
                : $"{property.Name} ");
        }

        sb.Append(">\n");

        if (!_isDouble) return sb.ToString();

        if (_canHaveNestedElements)
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

            sb.Append($"{textProperty.Value}\n");
        }

        sb.Append($"</{TagName}>\n");

        return sb.ToString();
    }
}