using System.Drawing;
using System.Globalization;

namespace Graphviz.Net.Attributes
{
    public class HtmlLabelFontTextItem : HtmlLabelTextItem
    {
        //TODO Fontname
        public HtmlLabelFontTextItem(string text, Color color = default, double fontSize = -1) : base(string.Empty)
        {
            var colorTag = color != default ? $" color=\"{color.Name.ToLowerInvariant()}\"" : string.Empty;
            var pointSizeTag = fontSize > 0 ? $" point-size=\"{fontSize.ToString(CultureInfo.InvariantCulture)}\"" : string.Empty;
            Text = $"<font{colorTag}{pointSizeTag}>{text}</font>";
        }
    }
}
