namespace GraphQLSubTest;

public sealed class Query
{
    public SlowEntity GetSlowEntity() => new();
}