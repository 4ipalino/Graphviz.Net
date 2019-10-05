using System.Collections.Generic;

namespace Graphviz.Net
{
    #region NodeStatement

    public interface IPort : IGraphVizWritable
    {
        string Id { get; }
        IEnumerable<Compass> Compasses { get; }
    }

    #endregion
}
