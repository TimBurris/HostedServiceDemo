namespace HostedServiceDemo.Api.HostedServices
{
    public class SmsStatusUpdaterHostedService : BackgroundService
    {
        private readonly ILogger<SmsStatusUpdaterHostedService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public SmsStatusUpdaterHostedService(ILogger<SmsStatusUpdaterHostedService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Execute called");

            using (var scope = _serviceProvider.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<MyRepository>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("check twilio");


                    await Task.Delay(TimeSpan.FromSeconds(5));
                }
            }


            _logger.LogInformation("Execute complete");
        }
    }
}
