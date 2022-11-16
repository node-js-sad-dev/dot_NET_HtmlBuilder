using HtmlBuilder.Properties;

namespace HtmlBuilder.Exceptions.PropertyExceptions;

public class PropertyShouldHaveValueException : Exception
{
    private readonly Property _propertyCausedError;

    public PropertyShouldHaveValueException(Property propertyCausedError)
    {
        _propertyCausedError = propertyCausedError;
    }
    
    public override string ToString()
    {
        return $"Property {_propertyCausedError.Name} should have value cause param HasValue was set to True";
    }
}