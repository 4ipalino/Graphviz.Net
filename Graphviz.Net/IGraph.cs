using Graphviz.Net.Generator;

namespace Graphviz.Net
{
    public interface IGraph : IGraphBase
    {

        bool IsStrict { get; }


        NodeStatement GetNode(string id);

        void Save(string file);
    }
}
