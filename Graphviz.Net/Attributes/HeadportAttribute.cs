using System.Linq;
using System.Text.RegularExpressions;

namespace Graphviz.Net.Attributes
{
    #region Attributes

    public class HeadportAttribute : Attribute
    {
        public HeadportAttribute(Compass compass)
        {
            Compass = compass;
        }

        public override string Id => "headport";

        public override string Value => string.Concat(Regex.Matches(Compass.ToString(), "[A-Z]").OfType<Match>().Select(match => match.Value)).ToLowerInvariant();

        public Compass Compass { get; }
    }

    #endregion
}
