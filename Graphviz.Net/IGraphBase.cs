using System.Collections.Generic;

namespace Graphviz.Net
{
    public interface IGraphBase : IGraphVizWritable
    {
        string Id { get; }

        IEnumerable<IStatement> Statements { get; }

        void AddStatement(IStatement statement);
    }
}
