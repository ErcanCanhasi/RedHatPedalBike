using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

public class MyController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string _apiKey;

    public MyController(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiKey = _configuration["ApiKey"];
        String s = _apiKey;
    }

    
}
