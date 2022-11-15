using HtmlBuilder.Elements;
using HtmlBuilder.Elements.P;

namespace HtmlBuilder
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HtmlElement div = new Div();
            
            div.Properties.Add("single-attr-test", null);
            div.Properties.Add("normal-attr-test", "test");

            HtmlElement p = new P();
            
            p.Properties.Add("Text", "Test");
            
            div.NestedElements.Add(p);

            var hb = (HtmlBuilder)div;
            
            hb.GenerateHtmlFile();
        }
    }
}

