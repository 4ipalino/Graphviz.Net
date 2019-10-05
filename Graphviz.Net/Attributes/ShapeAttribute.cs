namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class ShapeAttribute : Attribute
    {
        public ShapeAttribute(ShapeType shapeType)
        {
            ShapeType = shapeType;
        }

        public override string Id => "shape";

        public override string Value => ShapeType.ToString().ToLowerInvariant();

        public ShapeType ShapeType { get; }


    }

    #endregion
}
