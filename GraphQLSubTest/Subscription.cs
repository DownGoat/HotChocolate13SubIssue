namespace GraphQLSubTest;

public sealed class Subscription
{
    [Subscribe]
    [Topic("SubEntitySubscription")]
    public List<SubEntity> ListVessels([EventMessage] List<SubEntity> entities)
    {
        return entities;
    }
}