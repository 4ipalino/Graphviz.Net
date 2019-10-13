using Graphviz.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphviz.Net.Generator
{
    #region NodeStatement

    public class NodeStatement : IStatement
    {
        private List<IAttribute> _Attributes = new List<IAttribute>();

        public NodeStatement(string id, IEnumerable<IAttribute> attributes = null)
        {
            if (!id.IsValidId())
            {
                throw new ArgumentOutOfRangeException(nameof(id), $"Id \"{id}\" is not valid. More Information about valid Id´s: https://www.graphviz.org/doc/info/lang.html");
            }

            Id = id;
            if (attributes != null)
            {
                _Attributes.AddRange(attributes);
            }
        }

        public NodeStatement(string id, params IAttribute[] attributes) : this(id, attributes.ToList())
        {
        }

        public string Id { get; }

        public IPort Port { get; set; }

        public IEnumerable<IAttribute> Attributes => _Attributes;

        public void WriteText(IGraphvizBuilder gb)
        {
            gb.Append(Id);
            if (Port != null)
            {
                Port.WriteText(gb);
            }
            gb.Append('[');

            if (Attributes != null)
            {
                var isFirstAttribute = true;
                foreach (var attribute in Attributes)
                {
                    if (!isFirstAttribute)
                    {
                        gb.Append(';');
                    }
                    else
                    {
                        isFirstAttribute = false;
                    }
                    attribute.WriteText(gb);
                }
            }
            gb.Append(']');
            gb.AppendLine();
        }

        public NodeStatement WithAttribute(IAttribute attribute)
        {
            _Attributes.Add(attribute);
            return this;
        }
    }

    #endregion
}
