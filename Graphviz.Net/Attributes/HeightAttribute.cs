using System.Globalization;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class HeightAttribute : Attribute
    {
        public HeightAttribute(double height)
        {
            Height = height;
        }

        public override string Id => "height";

        public override string Value => Height.ToString(CultureInfo.InvariantCulture);

        public double Height { get; }
    }

    #endregion
}
