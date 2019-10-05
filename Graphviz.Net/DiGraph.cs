using System.Text;

namespace Graphviz.Net
{
    public class DiGraph : GraphBase
    {
        public override void WriteText(StringBuilder sb)
        {
            if (IsStrict)
            {
                sb.Append("strict ");
            }
            sb.Append("digraph ");
            sb.Append(Id);
            sb.AppendLine(" {");
            foreach (var statement in Statements)
            {
                statement.WriteText(sb);
            }

            sb.AppendLine("}");
        }
    }
}
