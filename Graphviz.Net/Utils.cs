using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Graphviz.Net.Generator
{
    internal static class Utils
    {
        internal static bool IsValidId(this string id)
        {
            return new Regex("^[a-zA-Z_][a-zA-Z0-9_]*$").IsMatch(id);
        }
    }
}
