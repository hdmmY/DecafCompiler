public class TokenMatch
{
    public TokenType TokenType;

    public string Value;

    public int StartIdx;

    public int EndIdx;

    public int Priority;

    public static TokenMatch Empty => new TokenMatch
    {
        TokenType = TokenType.None,
        StartIdx = -1,
        EndIdx = -1,
        Value = string.Empty,
        Priority = -1
    };
}