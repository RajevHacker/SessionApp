using Microsoft.AspNetCore.SignalR;
using SessionApp.Api.Application.Interfaces;

namespace SessionApp.Api.Hubs;

public class SessionHub : Hub
{
    private readonly ISessionService _sessionService;

    public SessionHub(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task JoinSession(string code)
    {
        // Validate session exists
        _sessionService.JoinSession(code);

        // Group users by session code
        await Groups.AddToGroupAsync(Context.ConnectionId, code);
    }

    public async Task UpdateState(string code, object state)
    {
        var session = _sessionService.JoinSession(code);
        session.UpdateState(state);

        await Clients
            .Group(code)
            .SendAsync("StateUpdated", state);
    }
}