namespace HtmlBuilder.Properties;

public struct PropertyDescription
{
    public readonly string name;
    public readonly bool hasValue;

    public PropertyDescription(string name, bool hasValue)
    {
        this.name = name;
        this.hasValue = hasValue;
    }
}