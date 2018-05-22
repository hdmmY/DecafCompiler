namespace Parser
{
    // Program ::= ClassDef + 
    public class ProgramSymbol : Symbol
    {

    }

    public class VariableDefSymbol : Symbol
    {

    }

    public class VariableSymbol : Symbol
    {

    }

    public class TypeSymbol : Symbol
    {

    }

    public class FormalsSymbol : Symbol
    {

    }

    public class FunctionDefSymbol : Symbol
    {

    }

    public class ClassDefSymbol : Symbol
    {

    }

    public class FieldSymbol : Symbol
    {

    }

    public class StmtBlockSymbol : Symbol
    {

    }

    public class StmtSymbol : Symbol
    {

    }

    public class SimpleStmtSymbol : Symbol
    {

    }

    public class LValueSymbol : Symbol
    {

    }

    public class CallSymbol : Symbol
    {

    }

    public class ActualsSymbol : Symbol
    {

    }

    public class ForStmtSymbol : Symbol
    {

    }

    public class WhileStmtSymbol : Symbol
    {

    }

    public class IfStmtSymbol : Symbol
    {

    }

    public class ReturnStmtSymbol : Symbol
    {

    }

    public class BreakStmtSymbol : Symbol
    {

    }

    public class PrintStmtSymbol : Symbol
    {

    }

    public class BoolExprSymbol : Symbol
    {

    }

    public class ExprSymbol : Symbol
    {

    }

    public class ConstantSymbol : Symbol
    {

    }

    public class TerminalSymbol : Symbol
    {
        public TokenType TokenType => _token.TokenType;

        public string Value => _token.Value;

        public int LineInfo => _token.LineInfo;

        private DecafToken _token;

        public TerminalSymbol (DecafToken token)
        {
            _token = token;
        }

        public override string ToString ()
        {
            return string.Format ("{0} - {1}", _token.TokenType, _token.Value);
        }
    }
}