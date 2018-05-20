using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Tokenizer
{
    private List<TokenDefinition> _tokenDefines;

    public Tokenizer ()
    {
        _tokenDefines = new List<TokenDefinition> ();

        // Reserved words
        _tokenDefines.Add (new TokenDefinition (TokenType.Bool, "bool"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Break, "break"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Class, "class"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Else, "else"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Extends, "extends"));
        _tokenDefines.Add (new TokenDefinition (TokenType.For, "for"));
        _tokenDefines.Add (new TokenDefinition (TokenType.If, "if"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Int, "int"));
        _tokenDefines.Add (new TokenDefinition (TokenType.New, "new"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Null, "null"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Return, "return"));
        _tokenDefines.Add (new TokenDefinition (TokenType.String, "string"));
        _tokenDefines.Add (new TokenDefinition (TokenType.This, "this"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Void, "void"));
        _tokenDefines.Add (new TokenDefinition (TokenType.While, "while"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Static, "static"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Print, "Print"));
        _tokenDefines.Add (new TokenDefinition (TokenType.ReadInteger, "ReadInteger"));
        _tokenDefines.Add (new TokenDefinition (TokenType.ReadLine, "ReadLine"));
        _tokenDefines.Add (new TokenDefinition (TokenType.Instanceof, "instanceof"));
        _tokenDefines.Add (new TokenDefinition (TokenType.True, "true"));
        _tokenDefines.Add (new TokenDefinition (TokenType.False, "false"));

        // Value    
        _tokenDefines.Add (new TokenDefinition (TokenType.IntegerValue,
            @"[+-]?(((0X|0x)([0-9]|[a-e]|[A-E])+)|(\d+))"));
        _tokenDefines.Add (new TokenDefinition (TokenType.DoubleValue,
            @"[+-]?\d+\.((\d*[+-]?[Ee]\d+)|\d*)"));
        _tokenDefines.Add (new TokenDefinition (TokenType.StringValue,
            "^\".* \"$"));

        // Operators
        _tokenDefines.Add (new TokenDefinition (TokenType.AddOp, @"\+"));
        _tokenDefines.Add (new TokenDefinition (TokenType.MinusOp, @"-"));
        _tokenDefines.Add (new TokenDefinition (TokenType.MutiOp, @"\*"));
        _tokenDefines.Add (new TokenDefinition (TokenType.DividOp, "/"));
        _tokenDefines.Add (new TokenDefinition (TokenType.ModOp, "%"));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessOp, "<"));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessEqualOp, "<="));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterOp, ">"));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterEqualOp, ">="));
        _tokenDefines.Add (new TokenDefinition (TokenType.EqualOp, "=="));
        _tokenDefines.Add (new TokenDefinition (TokenType.NotEqualOp, "!="));
        _tokenDefines.Add (new TokenDefinition (TokenType.AndOp, "&&"));
        _tokenDefines.Add (new TokenDefinition (TokenType.OrOp, "||"));
        _tokenDefines.Add (new TokenDefinition (TokenType.NorOp, "!"));

        // Punctuations
        _tokenDefines.Add (new TokenDefinition (TokenType.SemicolonPunc, ";"));
        _tokenDefines.Add (new TokenDefinition (TokenType.CommaPunc, ","));
        _tokenDefines.Add (new TokenDefinition (TokenType.DotPunc, @"\."));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftSquareBracketPunc, "["));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightSquareBracketPunc, "]"));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracketPunc, "("));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracketPunc, ")"));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracePunc, "{"));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracePunc, "}"));

        // Others
        _tokenDefines.Add (new TokenDefinition (TokenType.Assign, "="));
        _tokenDefines.Add (new TokenDefinition (TokenType.Identifier,
            "^([a-z]|[A-Z])(([a-z]|[A-Z]|[0-9]){0, 30})"));

    }

    public IEnumerable<DecafToken> Tokenize (string decafScript)
    {
        
    }

}