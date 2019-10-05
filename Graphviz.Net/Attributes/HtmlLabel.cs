using System;
using System.Linq;
using System.Text;

namespace Graphviz.Net.Attributes
{
    public class HtmlLabel : IGraphVizWritable
    {
        public HtmlLabel(HtmlLabelText text)
        {
            Text = text;
        }

        public HtmlLabel(HtmlLabelFontTable table)
        {
            throw new NotImplementedException();
        }

        public HtmlLabelText Text { get; }

        public void WriteText(StringBuilder sb)
        {
            sb.Append('<');
            if (Text != null)
            {
                foreach (var textItem in Text.TextItems)
                {
                    sb.Append(textItem.Text);
                }
            }
            sb.Append('>');
            sb.AppendLine();
        }
    }
}
