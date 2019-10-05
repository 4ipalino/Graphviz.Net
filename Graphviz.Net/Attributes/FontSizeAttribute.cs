using Graphviz.Net.Attributes;
using System.Globalization;

namespace Graphviz.Net.Attributes
{

    #region Attributes

    public class FontSizeAttribute : Attribute
    {
        public FontSizeAttribute(double fontSize)
        {
            Value = fontSize.ToString(CultureInfo.InvariantCulture);
        }

        public override string Id => "fontsize";
    }

    #endregion
}
