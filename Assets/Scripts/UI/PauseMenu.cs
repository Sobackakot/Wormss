using UnityEngine;

public class PauseMenu : UIMenu
{
    [SerializeField] private GameSatateSwitcher _gameSwitcher;

    public void ReturnGame()
    {
        _gameSwitcher.Unpause();
    }

    public void Restart()
    {
        _gameSwitcher.RestartGame();
    }

    public void ExitMainMenu()
    {
        _gameSwitcher.ExitMainMenu();
    }
}
