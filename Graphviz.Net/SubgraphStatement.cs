using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    #region SubgraphStatement

    public class SubgraphStatement : IStatement, IGraphBase
    {
        protected List<IStatement> _Statements = new List<IStatement>();

        public SubgraphStatement(string id)
        {
            Id = id;
        }

        public string Id { get; set; }

        public IEnumerable<IStatement> Statements => _Statements;

        public void AddStatement(IStatement statement)
        {
            _Statements.Add(statement);
        }

        public void WriteText(StringBuilder sb)
        {
            sb.Append("subgraph ");
            sb.Append(Id);
            sb.AppendLine(" {");
            foreach (var statement in Statements)
            {
                statement.WriteText(sb);
            }

            sb.AppendLine("}");
        }
    }

    #endregion
}
