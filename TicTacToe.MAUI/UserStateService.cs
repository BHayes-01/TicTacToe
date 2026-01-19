namespace TicTacToe;

public class UserStateService
{
    // Your persistent data
    public string CurrentUsername { get; set; }
    public List<string> SessionLogs { get; set; } = new();

    public void ClearState()
    {
        SessionLogs.Clear();
        CurrentUsername = string.Empty;
    }
}
