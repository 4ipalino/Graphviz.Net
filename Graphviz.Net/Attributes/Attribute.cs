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

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append(Id);
            gb.Append("=");
            //gb.Append('"');
            gb.Append(Value);
            //gb.Append('"');
        }
    }

    #endregion
}
