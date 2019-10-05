namespace Graphviz.Net.Attributes
{
    public class SplinesAttribute : Attribute
    {
        public SplinesAttribute(SplinesType splinesType)
        {
            SplinesType = splinesType;
        }
        public override string Id => "splines";

        public override string Value => SplinesType.ToString().ToLowerInvariant();

        public SplinesType SplinesType { get; }
    }
}
