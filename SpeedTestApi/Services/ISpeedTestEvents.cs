using SpeedTestApi.Models;

namespace SpeedTestApi.Services;

public interface ISpeedTestEvents
{
    Task PublishSpeedTest(TestResult speedTest);
}