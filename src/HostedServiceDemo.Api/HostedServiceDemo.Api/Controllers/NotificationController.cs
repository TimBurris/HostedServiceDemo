using HostedServiceDemo.Api.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace HostedServiceDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;
    private readonly MockHub _mockHub;

    public NotificationController(ILogger<NotificationController> logger,
        SignalR.MockHub mockHub)
    {
        _logger = logger;
        _mockHub = mockHub;
    }
    [HttpPost]
    public IActionResult Index([FromBody] string message)
    {
        _logger.LogInformation("message received {msg}", new { msg = message });
        _mockHub.Notify();
        return NoContent();
    }
}
