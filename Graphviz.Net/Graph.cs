using System.Text;

namespace Graphviz.Net
{
    public class Graph : GraphBase
    {
        public override bool IsStrict => true;

        public override void WriteText(IGraphvizBuilder gb)
        {
            gb.Append("strict graph ");
            gb.Append(Id);
            gb.AppendLine(" {");
            gb.IncreaseIndention();
            foreach (var statement in Statements)
            {
                statement.WriteText(gb);
            }
            gb.DecreaseIndention();
            gb.AppendLine("}");
        }
    }
}
