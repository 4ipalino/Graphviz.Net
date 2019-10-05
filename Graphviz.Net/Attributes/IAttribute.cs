namespace Graphviz.Net.Attributes
{
    public interface IAttribute : IGraphVizWritable
    {
        string Id { get; }
        string Value { get; }
    }
}
