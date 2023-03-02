using System.ComponentModel.DataAnnotations;

namespace SpeedTestApi.Models;

public record TestResult(
    Guid SessionId,

    [StringLength(500, MinimumLength = 2)]
    string User,

    [Range(1, int.MaxValue)]
    int Device,

    [Range(0, long.MaxValue)]
    long Timestamp,

    TestData Data);

public record TestData(
    TestSpeeds Speeds,

    TestClient Client,

    TestServer Server);

public record TestSpeeds(
    [Range(0, 3000)]
    double Download,

    [Range(0, 3000)]
    double Upload);

public record TestClient(
    [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")]
    string Ip,

    [Range(-90, 90)]
    double Latitude,

    [Range(-180, 180)]
    double Longitude,

    [StringLength(500, MinimumLength = 2)]
    string Isp,

    [Required]
    string Country);

public record TestServer(
    [StringLength(500, MinimumLength = 2)]
    string Host,

    [Range(-90, 90)]
    double Latitude,

    [Range(-180, 180)]
    double Longitude,

    [RegularExpression(@"^([A-Z]){2}$")]
    string Country,

    [Range(0, 21000000)]
    double Distance,

    [Range(0, int.MaxValue)]
    int Ping,

    [Range(0, int.MaxValue)]
    int Id);