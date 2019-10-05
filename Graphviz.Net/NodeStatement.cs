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

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append(Id);
            if (Port != null)
            {
                Port.WriteText(gb);
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
            gb.Append(']');
            gb.AppendLine();
        }
    }

    #endregion
}
