using HtmlBuilder.Properties;

namespace HtmlBuilder.Exceptions.PropertyExceptions;

public class PropertyCannotHaveValueException : Exception
{
    private readonly Property _propertyCausedError;

    public PropertyCannotHaveValueException(Property propertyCausedError)
    {
        _propertyCausedError = propertyCausedError;
    }

    public override string ToString()
    {
        return $"Property {_propertyCausedError.Name} cannot have value cause param HasValue was set to False";
    }
}