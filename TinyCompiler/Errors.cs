using System.Collections.Generic;

namespace TinyCompiler
{
    public static class Errors
    {
        public static List<string> Error_List = new List<string>();

        public static void Add(int lineNumber, string msg)
        {
            Error_List.Add($"[Line {lineNumber}]: {msg}.");
        }
    }
}
