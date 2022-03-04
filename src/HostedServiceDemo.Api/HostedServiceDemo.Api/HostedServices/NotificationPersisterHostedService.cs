using HostedServiceDemo.Api.SignalR;

namespace HostedServiceDemo.Api.HostedServices;


public class MyRepository
{

}

public class NotificationPersisterHostedService : IHostedService
{
    private readonly MockHub _mockHub;
    private readonly ILogger<NotificationPersisterHostedService> _logger;
    private readonly IServiceProvider _serviceProvider;

    public NotificationPersisterHostedService(SignalR.MockHub mockHub, ILogger<NotificationPersisterHostedService> logger, IServiceProvider serviceProvider)
    {
        _mockHub = mockHub;
        _logger = logger;
        _serviceProvider = serviceProvider;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _mockHub.VeryImportantNotification += _mockHub_VeryImportantNotification;

        return Task.CompletedTask;
    }

    private void _mockHub_VeryImportantNotification(object? sender, EventArgs e)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repo = scope.ServiceProvider.GetRequiredService<MyRepository>();

            _logger.LogInformation(repo == null ? "booooo" : "yay we have a repo");
            _logger.LogInformation("Written to database");

        }
        //_myRepository.AddEnity();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _mockHub.VeryImportantNotification -= _mockHub_VeryImportantNotification;
        return Task.CompletedTask;
    }
}
