using System.Runtime.CompilerServices;
using System.Text;

namespace HtmlBuilder;

public class HtmlBuilder
{
    private class HtmlElement
    {
        public string tagName;
        public Dictionary<string, string> properties = new Dictionary<string, string>();
        public List<HtmlElement> daughterElements = new List<HtmlElement>();

        public HtmlElement(string tagName)
        {
            this.tagName = tagName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<{tagName} ");

            foreach (var property in properties)
            {
                sb.Append($"{property.Key}=\"{property.Value}\" ");
            }

            sb.Append(">\n");

            foreach (var daughterElement in daughterElements)
            {
                sb.Append(daughterElement);
            }

            sb.Append($"</{tagName}>\n");

            return sb.ToString();
        }
    }

    private HtmlElement _htmlElement;

    public HtmlBuilder(string tagName)
    {
        _htmlElement = new HtmlElement(tagName);
    }

    public HtmlBuilder SetTagName(string tagName)
    {
        _htmlElement.tagName = tagName;

        return this;
    }

    public HtmlBuilder AddProperty(string key, string value)
    {
        _htmlElement.properties.Add(key, value);

        return this;
    }

    public HtmlBuilder AddProperty(Dictionary<string, string> properties)
    {
        foreach (var property in properties)
        {
            _htmlElement.properties.Add(property.Key, property.Value);
        }

        return this;
    }

    public HtmlBuilder SetProperties(Dictionary<string, string> properties)
    {
        _htmlElement.properties = properties;

        return this;
    }

    public HtmlBuilder ClearProperties()
    {
        _htmlElement.properties.Clear();

        return this;
    }

    // todo - make for removing properties

    public HtmlBuilder AddChild(HtmlBuilder htmlElem)
    {
        _htmlElement.daughterElements.Add(htmlElem._htmlElement);

        return this;
    }

    public HtmlBuilder AddChild(List<HtmlBuilder> children)
    {
        foreach (var child in children)
        {
            _htmlElement.daughterElements.Add(child._htmlElement);
        }

        return this;
    }

    public HtmlBuilder SetChildElements(List<HtmlBuilder> children)
    {
        _htmlElement.daughterElements.Clear();

        foreach (var child in children)
        {
            _htmlElement.daughterElements.Add(child._htmlElement);
        }

        return this;
    }

    public HtmlBuilder ClearChildren()
    {
        _htmlElement.daughterElements.Clear();

        return this;
    }

    public override string ToString()
    {
        return _htmlElement.ToString();
    }
}

public static class HtmlBuilderExtension
{
    public static void GenerateHtmlFile(this HtmlBuilder htmlBuilder)
    {
        File.WriteAllText("../../../test.html", htmlBuilder.ToString());
    }
}