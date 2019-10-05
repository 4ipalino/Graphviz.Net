namespace Graphviz.Net.Attributes
{
    public class HtmlLabelTextItem
    {
        public HtmlLabelTextItem(string text)
        {
            Text = text;
        }

        public string Text { get; protected set; }
    }
}
