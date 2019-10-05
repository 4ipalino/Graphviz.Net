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

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append('<');
            if (Text != null)
            {
                foreach (var textItem in Text.TextItems)
                {
                    gb.Append(textItem.Text);
                }
            }
            gb.Append('>');
        }
    }
}
