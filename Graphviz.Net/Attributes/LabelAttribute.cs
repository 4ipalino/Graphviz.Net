using System.Linq;
using System.Text;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class LabelAttribute : Attribute
    {
        public LabelAttribute(string label)
        {
            Value = $"\"{label}\"";
        }

        public LabelAttribute(params string[] lines)
        {
            Value = lines.Any() ? $"\"{string.Join(@"\n", lines)}\"" : string.Empty;
        }

        public LabelAttribute(HtmlLabel htmlLabel)
        {
            var gb = new GraphvizBuilder();
            htmlLabel.WriteText(gb);
            Value = gb.ToString();
        }

        public override string Id => "label";
    }

    #endregion
}
