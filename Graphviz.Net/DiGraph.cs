using System.Text;

namespace Graphviz.Net
{
    public class DiGraph : GraphBase
    {
        public override void WriteText(IGraphvizBuilder gb)
        {
            if (IsStrict)
            {
                gb.Append("strict ");
            }
            gb.Append("digraph ");
            gb.Append(Id);
            gb.AppendLine(" {");
            foreach (var statement in Statements)
            {
                statement.WriteText(gb);
            }

            gb.AppendLine("}");
        }
    }
}
