using System.Linq;
using System.Text;

namespace Graphviz.Net
{
    public interface IGraphVizWritable
    {
        void WriteText(IGraphvizBuilder gb);
    }

    public interface IGraphvizBuilder
    {
        void Append(string text);
        void Append(char c);

        void AppendLine();
        void AppendLine(string text);


        void IncreaseIndention();

        void DecreaseIndention();
    }

    public class GraphvizBuilder : IGraphvizBuilder
    {
        private readonly StringBuilder _StringBuilder = new StringBuilder();
        private int _Indention = 0;
        private int _TabSize = 4;

        private bool _IsNewLine = true;

        public void Append(string text)
        {
            AppendIndention();
            _StringBuilder.Append(text);
        }

        public void Append(char c)
        {
            AppendIndention();
            _StringBuilder.Append(c);
        }

        private void AppendIndention()
        {
            if (_IsNewLine && _Indention > 0)
            {
                _StringBuilder.Append(string.Join("", Enumerable.Repeat(" ", _Indention * _TabSize)));
            }
            _IsNewLine = false;
        }

        public void AppendLine()
        {
            AppendIndention();
            _StringBuilder.AppendLine();
            _IsNewLine = true;
        }

        public void AppendLine(string text)
        {
            AppendIndention();
            _StringBuilder.AppendLine(text);
            _IsNewLine = true;
        }

        public void DecreaseIndention()
        {
            _Indention--;
        }

        public void IncreaseIndention()
        {
            _Indention++;
        }

        public override string ToString()
        {
            return _StringBuilder.ToString();
        }
    }
}
