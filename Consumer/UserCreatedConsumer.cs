using MassTransit;
using Newtonsoft.Json;
using SharedFiles;

namespace Consumer;

public class UserCreatedConsumer : IConsumer<UserCreated>
{
    public Task Consume(ConsumeContext<UserCreated> context)
    {
        var jsonMessage =  JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"UserCreated message: {jsonMessage}");
        
        return Task.CompletedTask;
    }
}