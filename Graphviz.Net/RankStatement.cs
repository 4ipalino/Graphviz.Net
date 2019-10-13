using System.Collections.Generic;
using System.Linq;

namespace Graphviz.Net.Generator
{
    #region RankStatement

    public class RankStatement : IStatement, IGraphAppendNotifier
    {
        private readonly List<NodeStatement> _Nodes = new List<NodeStatement>();
        private readonly IEnumerable<string> _NodeIds;
        private IGraph _Graph;

        public RankStatement(IEnumerable<NodeStatement> nodes, bool withEdges)
        {
            _Nodes.AddRange(nodes);
            WithEdges = withEdges;
        }

        public RankStatement(IEnumerable<string> nodeIds, bool withEdges)
        {
            _NodeIds = nodeIds;
            WithEdges = withEdges;
        }

        public IEnumerable<NodeStatement> Nodes => _Nodes;

        /// <summary>
        /// If True the Nodes are Connected
        /// </summary>
        public bool WithEdges { get; }

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append("{ rank=same; ");
            var isFirst = true;
            foreach (var node in Nodes)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    if (WithEdges)
                    {
                        if (_Graph is DiGraph)
                        {
                            gb.Append(" -> ");
                        }
                        else
                        {
                            gb.Append(" -- ");
                        }
                    }
                    else
                    {
                        gb.Append("; ");
                    }
                }
                gb.Append(node.Id);
            }
            gb.Append('}');
            gb.AppendLine();
        }

        void IGraphAppendNotifier.AppendToGraph(IGraph graph)
        {
            _Graph = graph;
            if (_NodeIds != null)
            {
                _Nodes.AddRange(_NodeIds.Select(x => _Graph.GetNode(x)));
            }
        }
    }

    #endregion
}
