using Graphviz.Net.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    #region EdgeStatement

    public class EdgeStatement : IStatement, IGraphAppendNotifier
    {
        private IGraph _Graph;

        public EdgeStatement(NodeStatement fromNode, NodeStatement targetNode, IEnumerable<IAttribute> attributes = null, Port fromPort = null, Port targetPort = null)
        {
            FromNode = fromNode;
            TargetNode = targetNode;
            Attributes = attributes;
            FromPort = fromPort;
            TargetPort = targetPort;
        }

        public IEnumerable<IAttribute> Attributes { get; }
        public NodeStatement FromNode { get; }
        public NodeStatement TargetNode { get; }
        public Port FromPort { get; }
        public Port TargetPort { get; }

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append(FromNode.Id);
            if (FromPort != null)
            {
                FromPort.WriteText(gb);
            }

            if (_Graph is DiGraph)
            {
                gb.Append("->");
            }
            else
            {
                gb.Append("--");
            }
            gb.Append(TargetNode.Id);
            if (TargetPort != null)
            {
                TargetPort.WriteText(gb);
            }

            gb.Append('[');

            if (Attributes != null)
            {
                var isFirstAttribute = true;
                foreach (var attribute in Attributes)
                {
                    if (!isFirstAttribute)
                    {
                        gb.Append(';');
                    }
                    else
                    {
                        isFirstAttribute = false;
                    }
                    attribute.WriteText(gb);
                }
            }
            else
            {
            }
            gb.Append(']');
            gb.AppendLine();
        }

        void IGraphAppendNotifier.AppendToGraph(IGraph graph)
        {
            _Graph = graph;
        }
    }

    #endregion
}
