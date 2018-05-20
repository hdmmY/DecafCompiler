public enum TokenType
{
    None = 0,

    //  Reserved word 
    Bool,           // bool 
    Break,          // break
    Class,          // class
    Else,           // else
    Extends,        // extends
    For,            // for
    If,             // if
    Int,            // int
    New,            // new
    Null,           // null
    Return,         // return
    String,         // string
    This,           // this
    Void,           // void
    While,          // while
    Static,         // static
    Print,          // Print
    ReadInteger,    // ReadInteger
    ReadLine,       // ReadLine
    Instanceof,     // instanceof
    True,           // true constant
    False,          // false constant

    // Values
    //BooleanValue,   // boolean value
    IntegerValue,   // integer value
    DoubleValue,    // double value
    StringValue,    // string value

    // Operators
    AddOp,          // +
    MinusOp,        // -
    MutiOp,         // *
    DividOp,        // /
    ModOp,          // %
    LessOp,         // <
    LessEqualOp,    // <=
    GreaterOp,      // >
    GreaterEqualOp, // >=
    EqualOp,        // ==
    NotEqualOp,     // != 
    AndOp,          // &&
    OrOp,           // ||
    NorOp,          //  !
    
    // Punctuations
    SemicolonPunc,  // ;
    CommaPunc,      // ,
    DotPunc,        // .
    LeftSquareBracketPunc,  // [
    RightSquareBracketPunc, // ]
    LeftBracketPunc,        // (
    RightBracketPunc,       // )
    LeftBracePunc,          // {
    RightBracePunc,         // }

    // Others
    Assign,                // =
    Identifier,            // identifier

    // Commands
    OnLineCommand,         // //
    StarCommand,           // /*
    EndCommand             // */
}