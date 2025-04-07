using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TinyCompiler
{
    public class Node
    {
        public List<Node> Children = new List<Node>();

        public string Name;
        public Node(string name) => Name = name;
    }

    public class Parser
    {
        public Node root;
        private int _inputPointer;
        private List<Token> _tokenStream;

        public Node Parse(List<Token> tokenStreaam)
        {
            _inputPointer = 0;
            _tokenStream = tokenStreaam;
            root = Program();
            return root;
        }
        // done program
        private Node Program()
        {
            Node prog = new Node("Program");
            prog.Children.Add(Functiono_Statementso());
            prog.Children.Add(Main_Function());
            return prog;
        }

        
        // done main func
        private Node Main_Function()
        {
            Node Main_func = new Node("Main Function");

            Main_func.Children.Add(Datao_Typeo());
            if (Iso_Matcho(TokenClass.main))
            {
                Main_func.Children.Add(Matcho(TokenClass.main));
                Main_func.Children.Add(Matcho(TokenClass.LeftParanth));
                Main_func.Children.Add(Matcho(TokenClass.RightParanth));
                Main_func.Children.Add(Functiono_Bodyo());
            }
            else 
            {
                return null;
            }
            return Main_func;
        }
        // done func_states

        private Node Functiono_Statementso()
        {
            Node functionStatement = Functiono_Statemento();
            if (functionStatement == null)
            {
                return null;
            }
            Node functionState = new Node("Function Statements");
            functionState.Children.Add(functionStatement);
            if (Reado().type == TokenClass.Int && Reado_Nexto().type == TokenClass.main) 
            {
                return functionState;
            }
            Functiono_Statementso();

            return functionState;
        }
        // done func_state

        private Node Functiono_Statemento()
        {
            Node declare = Functiono_Declarationo();
            if (declare == null)
            {
                return null;
            }

            Node func_stat = new Node("Function Statement");
            func_stat.Children.Add(declare);
            func_stat.Children.Add(Functiono_Bodyo());

            return func_stat;
        }
        // done func_declare

        private Node Functiono_Declarationo()
        {
            Node dataType = Datao_Typeo();
            if (dataType == null)
            {
                return null;
            }

            Node Func_declare = new Node("Function Declaration");
            Func_declare.Children.Add(dataType);
            Func_declare.Children.Add(Identifiero());
            Func_declare.Children.Add(Matcho(TokenClass.LeftParanth));
            Func_declare.Children.Add(ParameterListo());
            Func_declare.Children.Add(Matcho(TokenClass.RightParanth));

            return Func_declare;
        }
        // done func_body

        private Node Functiono_Bodyo()
        {
            Node Func_body = new Node("Function Body");

            Func_body.Children.Add(Matcho(TokenClass.LeftBrace));
            Func_body.Children.Add(Statementso());
            Func_body.Children.Add(Returno_Statemento());
            Func_body.Children.Add(Matcho(TokenClass.RightBrace));

            return Func_body;
        }
        // done Func_call

        private Node Function_Call()
        {
            if (!Iso_Matcho(TokenClass.Identifier) || (Reado_Nexto().type != TokenClass.LeftParanth))
            {
                return null;
            }

            Node Func_call = new Node("Function Call");
            Func_call.Children.Add(Identifiero());
            Func_call.Children.Add(Matcho(TokenClass.LeftParanth));
            Func_call.Children.Add(ArgumentListo());
            Func_call.Children.Add(Matcho(TokenClass.RightParanth));

            return Func_call;
        }
        // done arg
        private Node Argumentso()
        {
            if (!Iso_Matcho(TokenClass.Comma))
            {
                return null;
            }

            Node Arg = new Node("Arguments");
            Arg.Children.Add(Matcho(TokenClass.Comma));
            Arg.Children.Add(Expressiono());
            Arg.Children.Add(Argumentso());

            return Arg;
        }
        // done arg_list

        private Node ArgumentListo()
        {
            if (Reado_Nexto().type == TokenClass.RightParanth)
            {
                return null;
            }

            Node Arg_list = new Node("Argument List");
            Arg_list.Children.Add(Expressiono());
            Arg_list.Children.Add(Argumentso());

            return Arg_list;
        }

       
        // done parameter

        private Node Parametero()
        {
            Node dataType = Datao_Typeo();
            if (dataType == null)
            {
                return null;
            }

            Node Param = new Node("Parameter");
            Param.Children.Add(dataType);
            Param.Children.Add(Identifiero());

            return Param;
        }

        // done params
        private Node Parameterso()
        {
            if (!Iso_Matcho(TokenClass.Comma))
            {
                return null;
            }

            Node Params = new Node("Parameters");
            Params.Children.Add(Matcho(TokenClass.Comma));
            Params.Children.Add(Parametero());
            Params.Children.Add(Parameterso());

            return Params;
        }
        // done params_list

        private Node ParameterListo()
        {
            Node parameter = Parametero();
            if (parameter == null)
            {
                return null;
            }

            Node Param_list = new Node("Parameter List");
            Param_list.Children.Add(parameter);
            Param_list.Children.Add(Parameterso());

            return Param_list;
        }


 
        // done statements

        private Node Statementso()
        {
            Node statement = Statemento();
            if (statement == null)
            {
                return null;
            }

            Node State = new Node("Statements");
            State.Children.Add(statement);
            State.Children.Add(Statementso());

            return State;
        }
        // done statement
        private Node Statemento()
            {
                Node statement = null;

            if (statement == null)
            {
                statement = Declareo_Statemento(); 
            }
            if (statement == null)
            {
                statement = Assignmento_Statemento(); 
            }
            if (statement == null)
            {
                statement = Writeo_Statemento(); 
            }
            if (statement == null)
            {
                statement = Reado_Statemento(); 
            }
            if (statement == null)
            {
                statement = Ifo_Statemento(); 
            }
            if (statement == null)
            {
                statement = Repeato_Statemento(); 
            }

            Node state = new Node("Statement");
                state.Children.Add(statement);

                return (statement != null) ? state : null;
            }
        // done return
        private Node Returno_Statemento()
        {
            if (!Iso_Matcho(TokenClass.Return))
            {
                return null;
            }

            Node Return = new Node("Return Statement");
            Return.Children.Add(Matcho(TokenClass.Return));
            Return.Children.Add(Expressiono());
            Return.Children.Add(Matcho(TokenClass.Semicolon));

            return Return;
        }
        // done assign

        private Node Assignmento_Statemento(bool matchSemiColon = true)
        {
            if ((!Iso_Matcho(TokenClass.Identifier) || (Reado_Nexto().type != TokenClass.Assign)))
            {
                return null;
            }

            Node Assign = new Node("Assignment Statement");
            Assign.Children.Add(Identifiero());
            Assign.Children.Add(Matcho(TokenClass.Assign));
            Assign.Children.Add(Expressiono());

            if (matchSemiColon)
            {
                Assign.Children.Add(Matcho(TokenClass.Semicolon));
            }

            return Assign;
        }
        // done write

        private Node Writeo_Statemento()
        {
            if (!Iso_Matcho(TokenClass.Write))
            {
                return null;
            }

            Node Write = new Node("Write Statement");

            Write.Children.Add(Matcho(TokenClass.Write));
            if (Iso_Matcho(TokenClass.Endl))
            {
                Write.Children.Add(Matcho(TokenClass.Endl));
            }
            else
            {
                Write.Children.Add(Expressiono());
            }
            Write.Children.Add(Matcho(TokenClass.Semicolon));

            return Write;
        }
        // done read

        private Node Reado_Statemento()
        {
            if (!Iso_Matcho(TokenClass.Read))
            {
                return null;
            }

            Node Read = new Node("Read Statement");
            Read.Children.Add(Matcho(TokenClass.Read));
            Read.Children.Add(Identifiero());
            Read.Children.Add(Matcho(TokenClass.Semicolon));

            return Read;
        }
        // done repeat

        private Node Repeato_Statemento()
        {
            if (!Iso_Matcho(TokenClass.Repeat))
            {
                return null;
            }

            Node repeat = new Node("Repeat Statement");
            repeat.Children.Add(Matcho(TokenClass.Repeat));
            repeat.Children.Add(Statementso());
            repeat.Children.Add(Matcho(TokenClass.Until));
            repeat.Children.Add(Conditiono_Statemento());

            return repeat;
        }
        // done if

        private Node Ifo_Statemento()
        {
            if (!Iso_Matcho(TokenClass.If))
            {
                return null;
            }

            Node IF = new Node("If Statement");

            IF.Children.Add(Matcho(TokenClass.If));
            IF.Children.Add(Conditiono_Statemento());
            IF.Children.Add(Matcho(TokenClass.Then));
            IF.Children.Add(Statementso());

            // Note: should return null if not matched
            IF.Children.Add(ElseIfo_Statemento());
            IF.Children.Add(Elseo_Statemento());

            IF.Children.Add(Matcho(TokenClass.End));

            return IF;
        }
        // done else_if

        private Node ElseIfo_Statemento()
        {
            if (!Iso_Matcho(TokenClass.ElseIf))
            {
                return null;
            }

            Node ELSE_if = new Node("ElseIf Statement");
            ELSE_if.Children.Add(Matcho(TokenClass.ElseIf));
            ELSE_if.Children.Add(Conditiono_Statemento());
            ELSE_if.Children.Add(Matcho(TokenClass.Then));
            ELSE_if.Children.Add(Statementso());

            // Note: should return null if not matched
            ELSE_if.Children.Add(ElseIfo_Statemento());
            ELSE_if.Children.Add(Elseo_Statemento());

            return ELSE_if;
        }
        // done else

        private Node Elseo_Statemento()
        {
            if (!Iso_Matcho(TokenClass.Else))
            {
                return null;
            }

            Node Else = new Node("Else Statement");
            Else.Children.Add(Matcho(TokenClass.Else));
            Else.Children.Add(Statementso());

            return Else;
        }


        // done conditionstat

        private Node Conditiono_Statemento()
        {
            Node Condition = new Node("Condition Statement");

            Condition.Children.Add(this.Conditiono());
            Condition.Children.Add(Conditionso());

            return Condition;
        }
        // done condition

        private Node Conditiono()
        {
            Node condition = new Node("Condition");

            condition.Children.Add(Identifiero());
            condition.Children.Add(Conditiono_Operatoro());
            condition.Children.Add(Termo());

            return condition;
        }
        // done conditions
        private Node Conditionso()
        {
            Node boolOpers = Booleano_Operatoro();
            if (boolOpers == null)
            {
                return null;
            }

            Node conditions = new Node("Conditions");
            conditions.Children.Add(boolOpers);
            conditions.Children.Add(Conditiono());
            conditions.Children.Add(Conditionso());

            return conditions;
        }
        // done condition_operator

        private Node Conditiono_Operatoro()
        {
            var ops = new[] { TokenClass.LessThan, TokenClass.GreaterThan, TokenClass.Equal, TokenClass.NotEqual };
            if (!ops.Contains(Reado().type))
            {
                return null;
            }

            Node cond_op = new Node("Condition Operator");
            cond_op.Children.Add(Matcho(Reado().type));

            return cond_op;
        }
        // done bool
        private Node Booleano_Operatoro()
        {
            Node BOOL = new Node("Boolean Operator");

            if (Iso_Matcho(TokenClass.And))
            {
                BOOL.Children.Add(Matcho(TokenClass.And));
            }
            else if (Iso_Matcho(TokenClass.Or))
            {
                BOOL.Children.Add(Matcho(TokenClass.Or));
            }
            else
            {
                return null;
            }

            return BOOL;
        }

        // done declare
        private Node Declareo_Statemento()
        {
            Node dataType = Datao_Typeo();
            if (dataType == null)
            {
                return null;
            }

            Node declare = new Node("Delcate Statement");
            declare.Children.Add(dataType);
            declare.Children.Add(Declarationso_Listo());
            declare.Children.Add(Matcho(TokenClass.Semicolon));

            return declare;
        }
        // done declaration
        private Node Declarationo()
        {
            Node declaration = new Node("Declaration");

            Node assignment = Assignmento_Statemento(false);
            declaration.Children.Add((assignment != null) ? assignment : Identifiero());

            return declaration;
        }
        // done declarations

        private Node Declarationso()
        {
            if (!Iso_Matcho(TokenClass.Comma))
            {
                return null;
            }

            Node declarations = new Node("Declarations");
            declarations.Children.Add(Matcho(TokenClass.Comma));
            declarations.Children.Add(Declarationo());
            declarations.Children.Add(Declarationso());

            return declarations;
        }
        // done declarations_list
        private Node Declarationso_Listo()
        {
            Node dec_list = new Node("Declaration List");

            dec_list.Children.Add(Declarationo());
            dec_list.Children.Add(Declarationso());

            return dec_list;
        }

        
        // done expression
        private Node Expressiono()
        {
            Node exp = new Node("Expression");
            exp.Children.Add((Iso_Matcho(TokenClass.StringLiteral) ? Stringo() : Equationo()));

            return exp;
        }
        // done ident

        private Node Identifiero()
        {
            Token tok = Reado();

            Node Ident = Matcho(TokenClass.Identifier);
            Ident?.Children.Add(new Node(tok.lex));

            return Ident;
        }
        // done datatype

        private Node Datao_Typeo()
        {
            var types = new[] { TokenClass.Int, TokenClass.Float, TokenClass.String };
            if (!types.Contains(Reado().type))
            {
                return null;
            }

            Node data_type = new Node("DataType");
            data_type.Children.Add(Matcho(Reado().type));

            return data_type;
        }

        // done term
        private Node Termo()
        {
            Node term = new Node("Term");

            if (Iso_Matcho(TokenClass.Number))
            {
                term.Children.Add(Numbero());
            }
            else if (Iso_Matcho(TokenClass.Identifier))
            {
                Node fCall = Function_Call();

                if (fCall != null)
                {
                    term.Children.Add(fCall);
                }
                else
                {
                    term.Children.Add(Identifiero());
                }
            }
            else
            {
                Erroro("Term", Reado());
                Advanceo();
            }

            return term;
        }
        // done str
        private Node Stringo()
        {
            Token t = Reado();

            Node str = Matcho(TokenClass.StringLiteral);
            str?.Children.Add(new Node(t.lex));

            return str;
        }
        // done num
        private Node Numbero()
        {
            Token t = Reado();

            Node Num = Matcho(TokenClass.Number);
            if (Num != null)
            {
                Node tempo = new Node(t.lex);
                Num.Children.Add(tempo);
            }

            return Num;
        }
        // done equation
        private Node Equationo()
        {
            Node equation = new Node("Equation");

            equation.Children.Add(Equationo_Termo());
            equation.Children.Add(EquationDasho());

            return equation;
        }
        // done equation_dash
        private Node EquationDasho()
        {
            Node addOp = Addo_Operatoro();
            if (addOp == null)
            {
                return null;
            }

            Node equ_dash = new Node("Equation Dash");
            equ_dash.Children.Add(addOp);
            equ_dash.Children.Add(Equationo_Termo());
            equ_dash.Children.Add(EquationDasho());

            return equ_dash;
        }
        // done equation_term
        private Node Equationo_Termo()
        {
            Node equ_term = new Node("Equataion Term");

            equ_term.Children.Add(Factoro());
            equ_term.Children.Add(Equationo_TermDasho());

            return equ_term;
        }
        // done equation_term_dash

        private Node Equationo_TermDasho()
        {
            Node mulOp = Mulo_Operatoro();
            if (mulOp == null)
            {
                return null;
            }

            Node equ_term_dash = new Node("Equation Term Dash");
            equ_term_dash.Children.Add(mulOp);
            equ_term_dash.Children.Add(Factoro());
            equ_term_dash.Children.Add(Equationo_TermDasho());

            return equ_term_dash;
        }
        // done factor
        private Node Factoro()
        {
            Node factor = new Node("Factor");

            if (Iso_Matcho(TokenClass.LeftParanth))
            {
                factor.Children.Add(Matcho(TokenClass.LeftParanth));
                factor.Children.Add(Equationo());
                factor.Children.Add(Matcho(TokenClass.RightParanth));
            }
            else
            {
                factor.Children.Add(Termo());
            }

            return factor;
        }
        // done add
        private Node Addo_Operatoro()
        {
            var ops = new[] { TokenClass.PlusOP, TokenClass.MinusOP };
            if (!ops.Contains(Reado().type))
            {
                return null;
            }

            Node add = new Node("Add Operator");
            add.Children.Add(Matcho(Reado().type));

            return add;
        }
        // done mult

        private Node Mulo_Operatoro()
        {
            var ops = new[] { TokenClass.MultiplyOP, TokenClass.DivideOP };
            if (!ops.Contains(Reado().type))
            {
                return null;
            }

            Node multi = new Node("Mul Operator");
            multi.Children.Add(Matcho(Reado().type));

            return multi;
        }

        private void Erroro(TokenClass expected)
        {
            Erroro(Reado().line, Token.TokenToString(expected), null);
        }

        private void Erroro(TokenClass expected, Token Acutal)
        {
            Erroro(Token.TokenToString(expected), Acutal);
        }

        private void Erroro(string expected, Token actual)
        {
            Erroro(actual.line, expected, actual.ToString());
        }

        private void Erroro(int line, string expected, string actual)
        {
            if (string.IsNullOrWhiteSpace(actual))
                Errors.Error_List.Add($"parser:{line}: error: expected '{expected}'.");
            else
                Errors.Error_List.Add($"parser:{line}: error: expected '{expected}', but found '{actual}'.");
        }

        private Token Reado()
        {
            if ((_inputPointer) < _tokenStream.Count)
            {
                return _tokenStream[_inputPointer];
            }

            return new Token();
        }

        private Token Reado_Nexto()
        {
            if ((_inputPointer + 1) < _tokenStream.Count)
            {
                return _tokenStream[_inputPointer + 1];
            }

            return new Token();
        }

        private bool Iso_Matcho(TokenClass tokenClass)
        {
            return (Reado().type == tokenClass);
        }

        private Node Matcho(TokenClass expectedToken)
        {
            if (_inputPointer < _tokenStream.Count)
            {
                if (expectedToken == _tokenStream[_inputPointer].type)
                {
                    Node newNode = new Node(expectedToken.ToString());
                    _inputPointer++;
                    return newNode;
                }
                else
                {
                    Erroro(expectedToken, _tokenStream[_inputPointer]);
                    _inputPointer++;
                }
            }
            else
            {
                Erroro(expectedToken);
                _inputPointer++;
            }

            return null;
        }

        private Token Advanceo() => (_inputPointer < _tokenStream.Count) ? _tokenStream[_inputPointer++] : null;

    }
}