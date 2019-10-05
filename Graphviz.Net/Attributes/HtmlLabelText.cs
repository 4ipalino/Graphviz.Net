using System.Collections.Generic;

namespace Graphviz.Net.Attributes
{
    public class HtmlLabelText
    {
        private List<HtmlLabelTextItem> _TextItems = new List<HtmlLabelTextItem>();

        public IEnumerable<HtmlLabelTextItem> TextItems => _TextItems;

        public HtmlLabelText WithTextItem(HtmlLabelTextItem textItem)
        {
            _TextItems.Add(textItem);
            return this;
        }
    }
}
