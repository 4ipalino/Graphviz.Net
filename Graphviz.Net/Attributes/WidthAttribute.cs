using System.Globalization;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class WidthAttribute : Attribute
    {
        public WidthAttribute(double width)
        {
            Width = width;
        }

        public override string Id => "width";

        public override string Value => Width.ToString(CultureInfo.InvariantCulture);

        public double Width { get; }
    }

    #endregion
}
