using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    public abstract class GraphBase : IGraph
    {
        protected List<IStatement> _Statements = new List<IStatement>();

        public string Id { get; set; }

        public virtual bool IsStrict { get; set; }


        public IEnumerable<IStatement> Statements => _Statements;

        public void AddStatement(IStatement statement)
        {
            _Statements.Add(statement);
            if (statement is IGraphAppendNotifier gn)
            {
                gn.AppendToGraph(this);
            }
        }

        public NodeStatement GetNode(string id)
        {
            return _Statements.OfType<NodeStatement>().FirstOrDefault(x => x.Id.Equals(id, StringComparison.Ordinal));
        }

        public void Save(string file)
        {
            var sb = new StringBuilder();
            WriteText(sb);
            File.WriteAllText(file, sb.ToString());
        }

        public abstract void WriteText(StringBuilder sb);
    }
}
