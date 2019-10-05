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
            var sb = new StringBuilder();
            htmlLabel.WriteText(sb);
            Value = sb.ToString();
        }

        public override string Id => "label";
    }

    #endregion
}
