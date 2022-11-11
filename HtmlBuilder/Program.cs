namespace HtmlBuilder
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HtmlBuilder div = new HtmlBuilder("div");
            HtmlBuilder p = new HtmlBuilder("p")
                .AddProperty("class", "test")
                .AddProperty("data-test", "test")
                .AddChild(new HtmlBuilder("ul").AddChild(new HtmlBuilder("li")));

            div.AddChild(p)
                .AddChild(p)
                .AddChild(p)
                .AddProperty("style", "color:blue");
            
            div.GenerateHtmlFile();
        }
    }
}

