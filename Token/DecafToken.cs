public class DecafToken
{
    public TokenType TokenType;

    public string Value;

    public int LineInfo;

    public DecafToken (TokenType tokenType, string value, int lineInfo)
    {
        TokenType = tokenType;
        Value = value;
        LineInfo = lineInfo;
    }
}