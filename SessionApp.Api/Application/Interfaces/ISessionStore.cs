using SessionApp.Api.Domain.Entities;

namespace SessionApp.Api.Application.Interfaces;

public interface ISessionStore
{
    Session Create();
    Session? Get(string code);
    void Update(Session session);
}