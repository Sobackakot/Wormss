using UnityEngine;

public class EndMenu : UIMenu
{
    [SerializeField] private GameSatateSwitcher _gameSwitcher;

    public void Restart()
    {
        _gameSwitcher.RestartGame();
    }

    public void ExitMainMenu()
    {
        _gameSwitcher.ExitMainMenu();
    }
}
