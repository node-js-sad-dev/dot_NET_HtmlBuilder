using HtmlBuilder.Builders;
using HtmlBuilder.Elements.BodyElements.WithNestedElements;
using HtmlBuilder.Properties;

namespace HtmlBuilder
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var p = new BodyHtmlElementBuilder(new P());

            p.AddProperty(new Property("Text", "Полностью сгенерированный кодом html файл"));

            var nestedDiv = new BodyHtmlElementBuilder(new Div());

            nestedDiv.AddNestedElement(p);

            var bodyBuilder = new BodyHtmlElementBuilder(new Div());

            bodyBuilder.AddNestedElement(nestedDiv);

            var htmlPageBuilder = new PageBuilder(bodyBuilder);

            htmlPageBuilder.GenerateHtmlFile(@"D:\test.html");
        }
    }
}