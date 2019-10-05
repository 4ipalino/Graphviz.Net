using System.Linq;
using System.Text;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public abstract class Attribute : IAttribute
    {
        //TODO Specific Attributes
        public abstract string Id { get; }

        public virtual string Value { get; protected set; }

        public void WriteText(StringBuilder sb)
        {
            sb.Append(Id);
            sb.Append("=");
            //sb.Append('"');
            sb.Append(Value);
            //sb.Append('"');
        }
    }

    #endregion
}
