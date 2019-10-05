namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class NodeStyleAttribute : Attribute
    {
        public NodeStyleAttribute(string style)
        {
            Value = style;
        }

        public NodeStyleAttribute(params NodeStyle[] nodeStyles)
        {
            Value = string.Join(", ", nodeStyles).ToLowerInvariant();
        }
        public override string Id => "style";
    }

    #endregion
}
