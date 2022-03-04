var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x => x.AddSeq());
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton<HostedServiceDemo.Api.SignalR.MockHub>();
builder.Services.AddScoped<HostedServiceDemo.Api.HostedServices.MyRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<HostedServiceDemo.Api.HostedServices.SmsNotifierHostedService>();
builder.Services.AddHostedService<HostedServiceDemo.Api.HostedServices.NotificationPersisterHostedService>();
builder.Services.AddHostedService<HostedServiceDemo.Api.HostedServices.SmsStatusUpdaterHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
