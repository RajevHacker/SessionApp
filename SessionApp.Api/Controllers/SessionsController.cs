using Microsoft.AspNetCore.Mvc;
using SessionApp.Api.Application.Interfaces;

namespace SessionApp.Api.Controllers;

[ApiController]
[Route("api/sessions")]
public class SessionsController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionsController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public IActionResult Create()
    {
        var session = _sessionService.CreateSession();

        return Ok(new
        {
            code = session.Code
        });
    }

    [HttpPost("{code}/join")]
    public IActionResult Join(string code)
    {
        try
        {
            _sessionService.JoinSession(code);
            return Ok();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpGet("healthCheck")]
    public IActionResult HealthCheck()
    {
        return Ok();
    }

}