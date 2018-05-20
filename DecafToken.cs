public class DecafToken
{
    public TokenType TokenType;

    public string Value;

    public DecafToken (TokenType tokenType)
    {
        TokenType = tokenType;
        Value = string.Empty;
    }

    public DecafToken (TokenType tokenType, string value)
    {
        TokenType = tokenType;
        Value = value;
    }
}