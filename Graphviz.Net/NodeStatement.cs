using Graphviz.Net.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    #region NodeStatement

    public class NodeStatement : IStatement
    {
        public NodeStatement(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public IPort Port { get; set; }

        public IEnumerable<IAttribute> Attributes { get; set; }

        public void WriteText(StringBuilder sb)
        {
            sb.Append(Id);
            if (Port != null)
            {
                Port.WriteText(sb);
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
            sb.Append(']');
            sb.AppendLine();
        }
    }

    #endregion
}
