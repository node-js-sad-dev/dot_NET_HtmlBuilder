using HtmlBuilder.Elements;
using HtmlBuilder.Properties;

namespace HtmlBuilder.Builders;

public abstract class HtmlElementBuilder<T>
    where T : HtmlElement<T>
{
    protected readonly T HtmlElement;

    protected HtmlElementBuilder(T htmlElement)
    {
        HtmlElement = htmlElement;
    }

    public HtmlElementBuilder<T> AddProperty(Property property)
    {
        HtmlElement.AddProperty(property);

        return this;
    }

    public HtmlElementBuilder<T> RemoveProperty(Property property)
    {
        HtmlElement.RemoveProperty(property);

        return this;
    }

    public HtmlElementBuilder<T> SetProperties(List<Property> properties)
    {
        HtmlElement.SetProperties(properties);

        return this;
    }

    public HtmlElementBuilder<T> ClearProperties()
    {
        HtmlElement.ClearProperties();

        return this;
    }

    public HtmlElementBuilder<T> AddNestedElement(T element)
    {
        HtmlElement.AddNestedElement(element);

        return this;
    }
    
    public HtmlElementBuilder<T> RemoveNestedElement(T element)
    {
        HtmlElement.RemoveNestedElement(element);

        return this;
    }
    
    public HtmlElementBuilder<T> SetNestedElements(List<T> elements)
    {
        HtmlElement.SetNestedElements(elements);

        return this;
    }

    public HtmlElementBuilder<T> ClearNestedElements()
    {
        HtmlElement.ClearNestedElements();

        return this;
    }
}