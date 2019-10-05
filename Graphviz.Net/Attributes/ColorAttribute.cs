using System.Drawing;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class ColorAttribute : Attribute
    {
        public ColorAttribute(Color color)
        {
            Color = color;
        }

        public override string Id => "color";

        public override string Value => Color.Name.ToLowerInvariant();

        public Color Color { get; }
    }

    #endregion
}
