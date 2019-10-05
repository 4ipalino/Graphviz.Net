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

        public void WriteText(StringBuilder sb)
        {
            sb.Append(FromNode.Id);
            if (FromPort != null)
            {
                FromPort.WriteText(sb);
            }

            if (_Graph is DiGraph)
            {
                sb.Append("->");
            }
            else
            {
                sb.Append("--");
            }
            sb.Append(TargetNode.Id);
            if (TargetPort != null)
            {
                TargetPort.WriteText(sb);
            }

            sb.Append('[');

            if (Attributes != null)
            {
                var isFirstAttribute = true;
                foreach (var attribute in Attributes)
                {
                    if (!isFirstAttribute)
                    {
                        sb.Append(';');
                    }
                    else
                    {
                        isFirstAttribute = false;
                    }
                    attribute.WriteText(sb);
                }
            }
            else
            {
            }
            sb.Append(']');
            sb.AppendLine();
        }

        void IGraphAppendNotifier.AppendToGraph(IGraph graph)
        {
            _Graph = graph;
        }
    }

    #endregion
}
