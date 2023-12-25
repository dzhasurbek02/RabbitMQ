using Consumer;
using MassTransit;

class Program
{
    static async Task Main(string[] args)
    {
        var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            MassTransitConfigurator.ConfigureMassTransit(null, cfg);
        });

        await busControl.StartAsync(new CancellationToken());

        try
        {
            Console.WriteLine("Press enter to exit");

            await Task.Run(() => Console.ReadLine());
        }
        finally
        {
            await busControl.StopAsync();
        }
    }
}