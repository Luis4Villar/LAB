using MassTransit;
using QueueReceiverService.QueueServices.SenderConsumer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RecetaConsumer>();
    x.UsingRabbitMq((context, config) =>
    {
   
        config.Host(new Uri("rabbitmq://localhost"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        config.ReceiveEndpoint("RecetaQueue", e =>
        {
            e.Consumer<RecetaConsumer>(context);
        });
        
    });
});

builder.Services.AddMassTransitHostedService();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
