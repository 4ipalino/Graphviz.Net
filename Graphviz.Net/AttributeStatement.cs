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

        public void WriteText(StringBuilder sb)
        {
            if (Type != AttributeType.None)
            {
                sb.Append(Type.ToString().ToLower());
                sb.Append('[');
            }

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
            if (Type != AttributeType.None)
            {
                sb.Append(']');
            }
            sb.AppendLine();
        }
    }

    #endregion
}
