using HtmlBuilder.Exceptions.PropertyExceptions;

namespace HtmlBuilder.Properties;

public class Property
{
    public readonly bool HasValue; // src="img_url" -> has value
    public readonly string Name;
    private string _value;

    public string Value
    {
        get => _value;
        set
        {
            if (!HasValue) throw new PropertyCannotHaveValueException(this);
            
            _value = value;
        }
    }

    public Property(string name)
    {
        HasValue = false;
        Name = name;
    }

    public Property(string name, string value)
    {
        HasValue = true;
        Name = name;
        Value = value;
    }
}