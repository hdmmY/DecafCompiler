using System.Text.RegularExpressions;


public class TokenDefinition
{
    private Regex _regex;
    private TokenType _tokenType;

    public TokenDefinition(TokenType tokenType, string regexPattern)
    {
        _tokenType = tokenType;
        _regex = new Regex(regexPattern, RegexOptions.None);
    }
}