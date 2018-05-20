using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Tokenizer
{
    private List<TokenDefinition> _tokenDefines;

    public Tokenizer ()
    {
        _tokenDefines = new List<TokenDefinition> ();

        // Reserved words
        _tokenDefines.Add (new TokenDefinition (TokenType.Bool, "bool", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Break, "break", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Class, "class", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Else, "else", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Extends, "extends", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.For, "for", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.If, "if", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Int, "int", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.New, "new", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Null, "null", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Return, "return", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.String, "string", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.This, "this", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Void, "void", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.While, "while", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Static, "static", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Print, "Print", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.ReadInteger, "ReadInteger", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.ReadLine, "ReadLine", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.Instanceof, "instanceof", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.True, "true", 100));
        _tokenDefines.Add (new TokenDefinition (TokenType.False, "false", 100));

        // Value    
        _tokenDefines.Add (new TokenDefinition (TokenType.IntegerValue,
            @"[+-]?(((0X|0x)([0-9]|[a-e]|[A-E])+)|(\d+))", 99));
        _tokenDefines.Add (new TokenDefinition (TokenType.DoubleValue,
            @"[+-]?\d+\.((\d*[Ee][+-]?\d+)|\d*)", 99));
        _tokenDefines.Add (new TokenDefinition (TokenType.StringValue,
            "\".*\"", 99));

        // Commands
        _tokenDefines.Add (new TokenDefinition (TokenType.OnLineCommand, @"//", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.StarCommand, @"/\*", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.EndCommand, @"\*/", 98));

        // Operators
        _tokenDefines.Add (new TokenDefinition (TokenType.AddOp, @"\+", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.MinusOp, @"-", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.MutiOp, @"\*", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.DividOp, "/", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.ModOp, "%", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessEqualOp, "<=", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterEqualOp, ">=", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.NotEqualOp, "!=", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.EqualOp, "==", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.AndOp, "&&", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.OrOp, @"\|\|", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessOp, "<", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterOp, ">", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.NorOp, "!", 96));

        // Punctuations
        _tokenDefines.Add (new TokenDefinition (TokenType.SemicolonPunc, ";", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.CommaPunc, ",", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.DotPunc, @"\.", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftSquareBracketPunc, @"\[", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightSquareBracketPunc, @"\]", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracketPunc, @"\(", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracketPunc, @"\)", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracePunc, @"\{", 95));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracePunc, @"\}", 95));

        // Others
        _tokenDefines.Add (new TokenDefinition (TokenType.Assign, "=", 94));
        _tokenDefines.Add (new TokenDefinition (TokenType.Identifier,
            @"([a-z]|[A-Z])([a-z]|[A-Z]|[0-9]|_)*", 94));

    }

    public List<DecafToken> Tokenize (string decafScript)
    {
        var tokenMatches = FindTokenMatches (decafScript)
            .GroupBy (x => x.StartIdx)
            .OrderBy (x => x.Key)
            .ToList ();

        TokenMatch lastMatch = null;

        List<DecafToken> result = new List<DecafToken> ();

        for (int i = 0; i < tokenMatches.Count; i++)
        {
            TokenMatch bestMatch = tokenMatches[i].OrderBy (x => x.Priority).Last ();

            if (lastMatch != null && bestMatch.StartIdx < lastMatch.EndIdx)
                continue;

            result.Add (new DecafToken (bestMatch.TokenType, bestMatch.Value));

            lastMatch = bestMatch;
        }

        return result;
    }

    private List<TokenMatch> FindTokenMatches (string decafScript)
    {
        List<TokenMatch> tokenMatches = new List<TokenMatch> ();

        foreach (var tokenDefine in _tokenDefines)
        {
            tokenMatches.AddRange (tokenDefine.FindMatches (decafScript));
        }

        return tokenMatches;
    }
}