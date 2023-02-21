using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLSubTest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ITopicEventSender _sender;

    public WeatherForecastController(ITopicEventSender sender)
    {
        _sender = sender;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Get(CancellationToken ct)
    {
        var random = new Random();
        var results = new List<SubEntity>()
        {
            new SubEntity()
            {
                TimeStamp = DateTime.Now,
                Int1 = random.Next(),
                Int2 = random.Next(),
                Int3 = random.Next(),
                Int4 = random.Next(),
                Int5 = random.Next(),
                Int6 = random.Next(),
                Int7 = random.Next(),
            },
            new SubEntity()
            {
                TimeStamp = DateTime.Now,
                Int1 = random.Next(),
                Int2 = random.Next(),
                Int3 = random.Next(),
                Int4 = random.Next(),
                Int5 = random.Next(),
                Int6 = random.Next(),
                Int7 = random.Next(),
            },
            new SubEntity()
            {
                TimeStamp = DateTime.Now,
                Int1 = random.Next(),
                Int2 = random.Next(),
                Int3 = random.Next(),
                Int4 = random.Next(),
                Int5 = random.Next(),
                Int6 = random.Next(),
                Int7 = random.Next(),
            }
        };
        
        await _sender.SendAsync("SubEntitySubscription", results, ct);

        return new ContentResult
        {
            Content = "Hello World",
            ContentType = "text/plain",
            StatusCode = 200
        };
    }
}