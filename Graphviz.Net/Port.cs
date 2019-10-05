using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Graphviz.Net
{
    #region NodeStatement

    public class Port : IPort
    {
        public Port(params Compass[] compasses)
        {
            Compasses = compasses;
        }

        public Port(string id, params Compass[] compasses)
        {
            Id = id;
            Compasses = compasses;
        }


        public string Id { get; set; }

        public IEnumerable<Compass> Compasses { get; }

        public void WriteText(StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                sb.Append(':');
                sb.Append(Id);
            }
            foreach (var compass in Compasses)
            {
                sb.Append(':');
                sb.Append(string.Concat(Regex.Matches(compass.ToString(), "[A-Z]").OfType<Match>().Select(match => match.Value)).ToLowerInvariant());
            }
        }
    }

    #endregion
}
