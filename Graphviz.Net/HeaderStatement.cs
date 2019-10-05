using Graphviz.Net.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Graphviz.Net
{
    #region HeaderStatement 
    public class HeaderStatement : IStatement
    {
        public HeaderStatement(IEnumerable<IAttribute> attributes)
        {
            Attributes = attributes;
        }

        public IEnumerable<IAttribute> Attributes { get; }

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append("HEADER");
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
