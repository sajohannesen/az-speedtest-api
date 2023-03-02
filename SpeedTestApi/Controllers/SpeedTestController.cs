using Microsoft.AspNetCore.Mvc;
using SpeedTestApi.Models;
using SpeedTestApi.Services;

namespace SpeedTestApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SpeedTestController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly ISpeedTestEvents _speedTestEvents;

    public SpeedTestController(ILogger<SpeedTestController> logger, ISpeedTestEvents speedTestEvents)
    {
        _logger = logger;
        _speedTestEvents = speedTestEvents;
    }
    
    // GET speedtest/ping
    [Route("ping")]
    [HttpGet]
    public string Ping()
    {
        return "PONG";
    }

    // POST speedtest/
    [HttpPost]
    public async Task<string> UploadSpeedTest([FromBody] TestResult speedTest)
    {
        await _speedTestEvents.PublishSpeedTest(speedTest);
        
        var response = $"Got a TestResult from { speedTest.User } with download { speedTest.Data.Speeds.Download } Mbps.";
        _logger.LogInformation(response);
        return response;
    }
}
