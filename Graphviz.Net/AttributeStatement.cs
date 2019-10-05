using Graphviz.Net.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    #region AttributeStatement

    public class AttributeStatement : IStatement
    {
        public AttributeStatement(AttributeType type, IEnumerable<IAttribute> attributes)
        {
            Type = type;
            Attributes = attributes;
        }

        public AttributeType Type { get; }
        public IEnumerable<IAttribute> Attributes { get; }

        public void WriteText(IGraphvizBuilder gb)
        {
            if (Type != AttributeType.None)
            {
                gb.Append(Type.ToString().ToLower());
                gb.Append('[');
            }

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
            if (Type != AttributeType.None)
            {
                gb.Append(']');
            }
            gb.AppendLine();
        }
    }

    #endregion
}
