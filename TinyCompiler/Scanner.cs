using System.Collections.Generic;

namespace TinyCompiler
{
    public enum TokenClass
    {
        LeftBrace, RightBrace, LeftParanth, RightParanth,
        MinusOP, PlusOP, MultiplyOP, DivideOP,
        Assign,
        LessThan, GreaterThan, Equal, NotEqual, And, Or, Comma, Semicolon,
        Int, Float, String, Read, Write, Repeat, Until, If, ElseIf, Else, End, Endl, Then, Return,
        Identifier, Number, StringLiteral,
        Undefined,
        main, FunctionCall,
    }

    public class Token
    {
        public string lex;
        public TokenClass type;
        public int line;
        private readonly static Dictionary<TokenClass, string> tokenToString = new Dictionary<TokenClass, string>
   {
       {TokenClass.LeftBrace, "{" },
       {TokenClass.RightBrace, "}" },
       {TokenClass.LeftParanth, "(" },
       {TokenClass.RightParanth, ")" },
       {TokenClass.MinusOP, "-" },
       {TokenClass.PlusOP, "+" },
       {TokenClass.MultiplyOP, "-" },
       {TokenClass.DivideOP, "/" },
       {TokenClass.Assign, ":=" },
       {TokenClass.LessThan, "<" },
       {TokenClass.GreaterThan, ">" },
       {TokenClass.Equal, "=" },
       {TokenClass.NotEqual, "<>" },
       {TokenClass.And, "&&" },
       {TokenClass.Or, "||" },
       {TokenClass.Comma, "," },
       {TokenClass.Semicolon, ";" },
};
        public static string TokenToString(TokenClass tokenClass)
        {
            if (tokenToString.ContainsKey(tokenClass))
            {
                return tokenToString[tokenClass];
            }

            return tokenClass.ToString().ToLower();
        }

        public override string ToString()
        {
            return TokenToString(type);
        }

    }

    public class Scanner
    {
        public List<Token> Tokens = new List<Token>();

        private static Dictionary<string, TokenClass> ReservedWords = new Dictionary<string, TokenClass>{

            {"int", TokenClass.Int},
            {"float", TokenClass.Float},
            {"string", TokenClass.String},
            {"write", TokenClass.Write},
            {"read", TokenClass.Read},
            {"repeat", TokenClass.Repeat},
            {"until", TokenClass.Until},
            {"if", TokenClass.If},
            {"elseif", TokenClass.ElseIf},
            {"else", TokenClass.Else},
            {"then", TokenClass.Then},
            {"return", TokenClass.Return},
            {"end", TokenClass.End},
            {"endl", TokenClass.Endl},
            {"main", TokenClass.main},
        };

        private int Start;
        private int Current;
        private int LineNumber = 1;
        private string SourceCode;

        public List<Token> Scan(string sourceCode)
        {
            Tokens.Clear();
            SourceCode = sourceCode;
            LineNumber = 1;
            Start = 0;
            Current = 0;

            while (!Finished())
            {
                Start = Current;
                char CurrentChar = Read();

                if (CurrentChar == '{')
                {
                    AddToken(TokenClass.LeftBrace);
                }
                else if (CurrentChar == '}')
                {
                    AddToken(TokenClass.RightBrace);
                }
                else if (CurrentChar == '(')
                {
                    AddToken(TokenClass.LeftParanth);
                }
                else if (CurrentChar == ')')
                {
                    AddToken(TokenClass.RightParanth);
                }
                else if (CurrentChar == ';')
                {
                    AddToken(TokenClass.Semicolon);
                }
                else if (CurrentChar == ',')
                {
                    AddToken(TokenClass.Comma);
                }
                else if (CurrentChar == '-')
                {
                    AddToken(TokenClass.MinusOP);
                }
                else if (CurrentChar == '+')
                {
                    AddToken(TokenClass.PlusOP);
                }
                else if (CurrentChar == '*')
                {
                    AddToken(TokenClass.MultiplyOP);
                }
                else if (CurrentChar == '/')
                {
                    if (MatchNext('*'))
                    {
                        ReadComment();
                    }
                    else
                    {
                        AddToken(TokenClass.DivideOP);
                    }
                }
                else if (CurrentChar == ':')
                {
                    if (MatchNext('='))
                    {
                        AddToken(TokenClass.Assign);
                    }
                }
                else if (CurrentChar == '=')
                {
                    AddToken(TokenClass.Equal);
                }
                else if (CurrentChar == '>')
                {
                    AddToken(TokenClass.GreaterThan);
                }
                else if (CurrentChar == '<')
                {
                    if (MatchNext('>'))
                    {
                        AddToken(TokenClass.NotEqual);
                    }
                    else
                    {
                        AddToken(TokenClass.LessThan);
                    }
                }
                else if (CurrentChar == '&')
                {
                    if (MatchNext('&'))
                    {
                        AddToken(TokenClass.And);
                    }
                    else 
                    {
                        Errors.Add(LineNumber, $"unexpected lexeme '{CurrentChar}'");
                    }

                }
                else if (CurrentChar == '|')
                {
                    if (MatchNext('|'))
                    {
                        AddToken(TokenClass.Or);
                    }
                    else
                    {
                        Errors.Add(LineNumber, $"unexpected lexeme '{CurrentChar}'");
                    }

                }
                else if (CurrentChar == '"')
                {
                    ReadString();
                }
                else if (CurrentChar == '\r' || CurrentChar == '\t' || CurrentChar == ' ')
                {
                }
                else if (CurrentChar == '\n')
                {
                    LineNumber++;
                }
                else if (char.IsDigit(CurrentChar))
                {
                    ReadNumber();
                }
                else if (char.IsLetter(CurrentChar))
                {
                    ReadIdentifier();
                }

                else
                {
                    Errors.Add(LineNumber, $"unexpected lexeme '{CurrentChar}'");
                }
            }

            return Tokens;
        }

        private void ReadIdentifier()
        {

            while (char.IsLetterOrDigit(readCurrent()))
                Read();
            string lex = SourceCode.Substring(Start, Current - Start);
            if (lex == "main") 
            {
                AddToken(TokenClass.main);
                return;
            }
            AddToken(ReservedWords.ContainsKey(lex) ? ReservedWords[lex] : TokenClass.Identifier);
        }

        private void ReadNumber()
        {

            while (char.IsDigit(readCurrent()))
                Read();

            if (readCurrent() == '.' && char.IsDigit(readNext()))
            {
                Read();
                while (char.IsDigit(readCurrent()))
                    Read();
            }
            if (char.IsLetter(readCurrent()))
            {
                Errors.Add(LineNumber, "Identitfier cannot begin with number.");
                while (char.IsLetterOrDigit(readCurrent()))
                    Read();
                return;
            }
            AddToken(TokenClass.Number);
        }

        private void ReadString()
        {
            char prev = '\0';
            while (!Finished())
            {
                if ((readCurrent() == '"') && (prev != '\\'))
                    break;

                if (readCurrent() == '\n')
                    break;

                prev = Read();
            }

            if (MatchNext('"'))
                AddToken(TokenClass.StringLiteral);
            else
                Errors.Add(LineNumber, "unterminated string, expected '\"'");
        }

        private void ReadComment()
        {
            while (!Finished())
            {
                if ((readCurrent() == '*') && (readNext() == '/'))
                {
                    Read();
                    break;
                }

                if (Read() == '\n')
                    LineNumber++;
            }

            if (readCurrent() == '/')
                Read();
            else
                Errors.Add(LineNumber, "unterminated comment, expected '*/'");
        }

        private void AddToken(TokenClass type)
        {
            Token token = new Token
            {
                lex = SourceCode.Substring(Start, Current - Start),
                type = type,
            };  

            Tokens.Add(token);
        }

        private char Read()
        {
            return SourceCode[Current++];
        }

        private char readCurrent()
        {
            if (Finished())
                return '\0';

            return SourceCode[Current];
        }

        private char readNext()
        {
            if (Current + 1 >= SourceCode.Length)
                return '\0';

            return SourceCode[Current + 1];
        }

        private bool MatchNext(char CurrentChar)
        {
            if (Finished())
                return false;

            if (SourceCode[Current] != CurrentChar)
                return false;

            Current++;
            return true;
        }

        private bool Finished() => (Current >= SourceCode.Length);
    }
}
