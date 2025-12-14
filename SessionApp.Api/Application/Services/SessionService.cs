using SessionApp.Api.Application.Interfaces;
using SessionApp.Api.Domain.Entities;

namespace SessionApp.Api.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionStore _sessionStore;

    public SessionService(ISessionStore sessionStore)
    {
        _sessionStore = sessionStore;
    }

    public Session CreateSession()
    {
        return _sessionStore.Create();
    }

    public Session JoinSession(string code)
    {
        var session = _sessionStore.Get(code);

        if (session is null)
            throw new InvalidOperationException("Invalid session code");

        return session;
    }
}