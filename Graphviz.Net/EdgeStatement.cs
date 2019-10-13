using Graphviz.Net.Attributes;
using Graphviz.Net.Generator;
using System;
using System.Collections.Generic;

namespace Graphviz.Net
{
    #region EdgeStatement

    public class EdgeStatement : IStatement, IGraphAppendNotifier
    {
        private readonly string _FromNodeId;
        private readonly string _TargetNodeId;
        private IGraph _Graph;

        public EdgeStatement(string fromNodeId, string targetNodeId, IEnumerable<IAttribute> attributes = null, Port fromPort = null, Port targetPort = null) : this((NodeStatement)null, (NodeStatement)null, attributes, fromPort, targetPort)
        {
            if (string.IsNullOrEmpty(fromNodeId) || string.IsNullOrEmpty(targetNodeId))
            {
                throw new ArgumentOutOfRangeException(fromNodeId, "from and target node id should not be null or empty");
            }
            _FromNodeId = fromNodeId;
            _TargetNodeId = targetNodeId;
        }

        public EdgeStatement(NodeStatement fromNode, NodeStatement targetNode, IEnumerable<IAttribute> attributes = null, Port fromPort = null, Port targetPort = null)
        {
            FromNode = fromNode;
            TargetNode = targetNode;
            Attributes = attributes;
            FromPort = fromPort;
            TargetPort = targetPort;
        }

        public IEnumerable<IAttribute> Attributes { get; }
        public NodeStatement FromNode { get; private set; }
        public NodeStatement TargetNode { get; private set; }
        public Port FromPort { get; }
        public Port TargetPort { get; }
        public string FromNodeId { get; }

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

            if (!string.IsNullOrEmpty(_FromNodeId))
            {
                FromNode = _Graph.GetNode(_FromNodeId);
                TargetNode = _Graph.GetNode(_TargetNodeId);
            }
        }
    }

    #endregion
}
