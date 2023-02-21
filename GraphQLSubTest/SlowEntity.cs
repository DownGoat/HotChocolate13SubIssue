namespace GraphQLSubTest;

public sealed class SlowEntity
{
    public string Prop1
    {
        get
        {
            Thread.Sleep(10000);
            return "Prop1";
        }
        init {}
    }
    
    
    public string Prop2
    {
        get
        {
            Thread.Sleep(20000);
            return "Prop2";
        }
        init {}
    }
    
    public string Prop3
    {
        get
        {
            Thread.Sleep(30000);
            return "Prop3";
        }
        init {}
    }
    
    public string Prop4
    {
        get
        {
            Thread.Sleep(40000);
            return "Prop4";
        }
        init {}
    }
}