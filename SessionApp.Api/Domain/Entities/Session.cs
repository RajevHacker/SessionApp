namespace SessionApp.Api.Domain.Entities;

public class Session
{
    public string Code { get; private set; }
    public object? State { get; private set; }

    public Session(string code)
    {
        Code = code;
    }

    public void UpdateState(object state)
    {
        State = state;
    }
}