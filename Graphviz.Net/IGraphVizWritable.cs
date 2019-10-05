using System.Text;

namespace Graphviz.Net
{
    public interface IGraphVizWritable
    {
        void WriteText(StringBuilder sb);
    }
}
