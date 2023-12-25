using Consumer;
using MassTransit;

namespace Publisher;

public static class MassTransitConfigurator
{
    public static void ConfigureMassTransit(IBusRegistrationContext context, IRabbitMqBusFactoryConfigurator configurator)
    {
        configurator.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        configurator.ReceiveEndpoint("user-created-event", e =>
        {
            e.Consumer<UserCreatedConsumer>();
        });
    }
}