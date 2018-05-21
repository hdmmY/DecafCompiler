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

        _tokenDefines.Add (new TokenDefinition (TokenType.MutiLineCommand, @"/\*(.|\n)*\*/", 102));
        _tokenDefines.Add (new TokenDefinition (TokenType.OnLineCommand, @"//.*\r?$", 101));

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

        // Operators
        _tokenDefines.Add (new TokenDefinition (TokenType.AddOp, @"\+", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.MinusOp, @"-", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.MutiOp, @"\*", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.DividOp, "/", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.ModOp, "%", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessEqualOp, "<=", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterEqualOp, ">=", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.NotEqualOp, "!=", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.EqualOp, "==", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.AndOp, "&&", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.OrOp, @"\|\|", 98));
        _tokenDefines.Add (new TokenDefinition (TokenType.LessOp, "<", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.GreaterOp, ">", 97));
        _tokenDefines.Add (new TokenDefinition (TokenType.NorOp, "!", 97));

        // Punctuations
        _tokenDefines.Add (new TokenDefinition (TokenType.SemicolonPunc, ";", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.CommaPunc, ",", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.DotPunc, @"\.", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftSquareBracketPunc, @"\[", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightSquareBracketPunc, @"\]", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracketPunc, @"\(", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracketPunc, @"\)", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.LeftBracePunc, @"\{", 96));
        _tokenDefines.Add (new TokenDefinition (TokenType.RightBracePunc, @"\}", 96));

        // Others
        _tokenDefines.Add (new TokenDefinition (TokenType.Assign, "=", 94));
        _tokenDefines.Add (new TokenDefinition (TokenType.Identifier,
            @"([a-z]|[A-Z])([a-z]|[A-Z]|[0-9]|_)*", 94));

    }

    public List<DecafToken> Tokenize (string decafScript)
    {
        var matchedLines = new Regex (@"\r$", RegexOptions.Multiline)
            .Matches (decafScript);

        int[] lineInfos = new int[matchedLines.Count];
        for (int i = 1; i < matchedLines.Count; i++)
        {
            lineInfos[i] = matchedLines[i - 1].Index + 1;
        }

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

            if (bestMatch.TokenType != TokenType.OnLineCommand &&
                bestMatch.TokenType != TokenType.MutiLineCommand)
            {
                result.Add (new DecafToken (bestMatch.TokenType, bestMatch.Value,
                    FindLineInfo (lineInfos, bestMatch.StartIdx)));
            }

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

    private int FindLineInfo (int[] lines, int startIdx)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (startIdx < lines[i])
            {
                return i;
            }
        }

        return lines.Length;
    }
}