using System.Drawing;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class FillColorAttribute : Attribute
    {
        public FillColorAttribute(Color color)
        {
            Color = color;
        }

        public override string Id => "fillcolor";

        public override string Value => Color.Name.ToLowerInvariant();

        public Color Color { get; }
    }

    #endregion
}
