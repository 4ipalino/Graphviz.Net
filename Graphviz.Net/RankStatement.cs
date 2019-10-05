using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    #region RankStatement

    public class RankStatement : IStatement, IGraphAppendNotifier
    {
        private IGraph _Graph;

        public RankStatement(IEnumerable<NodeStatement> nodes, bool withLines)
        {
            Nodes = nodes;
            WithLines = withLines;
        }

        public IEnumerable<NodeStatement> Nodes { get; }

        /// <summary>
        /// If True the Nodes are Connected
        /// </summary>
        public bool WithLines { get; }

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
                    if (WithLines)
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
        }
    }

    #endregion
}
