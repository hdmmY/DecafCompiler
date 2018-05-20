using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TokenDefinition
{
    private Regex _regex;
    private readonly TokenType _tokenType;
    private readonly int _priority;

    public TokenDefinition (TokenType tokenType, string regexPattern, int priority)
    {
        _tokenType = tokenType;
        _priority = priority;
        _regex = new Regex (regexPattern, RegexOptions.None);
    }

    public IEnumerable<TokenMatch> FindMatches (string inputString)
    {
        var matches = _regex.Matches (inputString);

        for (int i = 0; i < matches.Count; i++)
        {
            yield return new TokenMatch
            {
                TokenType = _tokenType,
                Value = matches[i].Value,
                StartIdx = matches[i].Index,
                EndIdx = matches[i].Index + matches[i].Length,
                Priority = _priority
            };
        }
    }
}