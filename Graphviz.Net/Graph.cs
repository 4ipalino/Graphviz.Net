using System.Text;

namespace Graphviz.Net
{
    public class Graph : GraphBase
    {
        public override bool IsStrict => true;

        public override void WriteText(StringBuilder sb)
        {
            sb.Append("strict graph ");
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
