using SessionApp.Api.Domain.Entities;

namespace SessionApp.Api.Application.Interfaces;

public interface ISessionService
{
    Session CreateSession();
    Session JoinSession(string code);
}