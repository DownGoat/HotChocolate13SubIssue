# HotChocolate13SubIssue
Example repo for HC Issue https://github.com/ChilliCream/graphql-platform/issues/5877

> ### Is there an existing issue for this?
> 
>     * [x]  I have searched the existing issues
> 
> 
> ### Product
> 
> Hot Chocolate
> ### Describe the bug
> 
> Subscription topic randomly stops working after some time. The client is still subscribed and ping/pongs are still being sent, and new messages arrive for some topics except for the failed one. It's not limited to a specific topic, sometimes _topicA_ fails, another time it's _topicB_, but eventually they all fail.
> 
> I have made a minimal solution that can be used to reproduce the issue, you can find it in this repo: https://github.com/DownGoat/HotChocolate13SubIssue
> 
> It has a single query that has properties that takes some time to resolve (simulating dataloaders, and slow db calls), and a single subscription that returns some random data. This is very similar to our setup for our project where a controller endpoint is being sent data every 5 seconds that it pushes to the topic that usually stalls first. It is the topic that has the most subscribers, and the only one that frequently sends new messages.
> 
> I have tested the same solution with version 12.17.0, and I have not managed to reproduce the issue. We first noticed it after upgrading to version 13.
> ### Steps to reproduce
> 
>     1. Start the following subscription
>        `subscription VesselPositions {   listVessels { timeStamp int1 int2 int3   } }`
> 
>     2. Send data to the topic by sending a GET request to `https://localhost:5001/WeatherForecast`. This endpoint sends a list of three entities with random data for the _intN_ fields and the current time. I use postman to repeat this request forever with a 10ms delay between each request.
> 
>     3. Start and stop the subscription in BCP, after some tries the subscription stalls, and you wont be getting any new data. If this is taking a lot of time, try opening a new tab in BCP where you run the following query, while it resolves continue starting and stopping the subscription. `query WatchingPaintDry {   slowEntity { prop1 prop2 prop3 prop4   } }`
> 
> 
> ### Relevant log output
> 
> _No response_
> ### Additional Context?
> 
> _No response_
> ### Version
> 
> 13.x.x

