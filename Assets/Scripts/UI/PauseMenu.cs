using UnityEngine;

public class PauseMenu : UIMenu
{
    [SerializeField] private GameSatateSwitcher _gameSwitcher;

    public void ReturnGame()
    {
        Time.timeScale = 1f;
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
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
}
