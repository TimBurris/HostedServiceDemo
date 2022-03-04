namespace HostedServiceDemo.Api.SignalR
{
    public class MockHub
    {
        private readonly ILogger<MockHub> _logger;

        public event EventHandler VeryImportantNotification;

        public MockHub(ILogger<MockHub> logger)
        {
            _logger = logger;
        }
        public void Notify()
        {
            _logger.LogInformation("Notify was called");
            this.VeryImportantNotification?.Invoke(this, EventArgs.Empty);
        }
    }
}
