namespace HtmlBuilder;

public static class HtmlBuilderExtension
{
    public static void GenerateHtmlFile(this HtmlBuilder htmlBuilder)
    {
        File.WriteAllText("../../../test.html", htmlBuilder.ToString());
    }
}