using System.Collections.Generic;
using System.Linq;

namespace TinyCompiler
{
    public static class Compiler
    {
        public static Scanner tinyo_Scannero = new Scanner();
        public static Parser Parsero = new Parser();
        public static List<string> Lexemeso = new List<string>();
        public static List<Token> Tokeno_Streamo = new List<Token>();
        public static Node treeo_Rooto;

        public static void Compile(string sourceCode)
        {
            Errors.Error_List.Clear();
            Tokeno_Streamo.Clear();

            //Scanner
            Tokeno_Streamo = tinyo_Scannero.Scan(sourceCode);

            //Parser
            Parsero.Parse(Tokeno_Streamo);
            treeo_Rooto = Parsero.root;
            
        }
    }
}
