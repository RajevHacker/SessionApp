using SessionApp.Api.Application.Interfaces;
using SessionApp.Api.Domain.Entities;
using System.Collections.Concurrent;

namespace SessionApp.Api.Infrastructure.Stores;

public class InMemorySessionStore : ISessionStore
{
    private readonly ConcurrentDictionary<string, Session> _sessions = new();

    public Session Create()
    {
        var code = Guid.NewGuid().ToString("N")[..6].ToUpper();
        var session = new Session(code);

        _sessions[code] = session;
        return session;
    }

    public Session? Get(string code)
    {
        _sessions.TryGetValue(code, out var session);
        return session;
    }

    public void Update(Session session)
    {
        _sessions[session.Code] = session;
    }
}