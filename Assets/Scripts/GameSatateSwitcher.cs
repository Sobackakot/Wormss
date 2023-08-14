using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSatateSwitcher : MonoBehaviour
{
    [SerializeField] private int _loadMainMenuId;
    [SerializeField] private GameObject _mapPrefab;
    [Header("Scene Reference")]
    [SerializeField] private Worm[] _players;
    [SerializeField] private BombHolder _bombHolder;
    [SerializeField] private GameObject _map;
    [SerializeField] private SwitchPlayers _playerSwitcher;
    [SerializeField] private InterfaceSwitcher _interfaceHolder;

    private bool _isPause;
    private float _physicSteap;

    private void OnEnable()
    {
        foreach (var worm in _players)
        {
            worm.OnDead += EndMenu;
        }
    }

    private void OnDisable()
    {
        foreach (var worm in _players)
        {
            worm.OnDead -= EndMenu;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPause)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }

    #region Pause
    public void Pause()
    {
        Stop();
        _isPause = true;
        _interfaceHolder.ShowMenu(MenuType.PauseMenu);
    }

    public void Unpause()
    {
        Play();
        _isPause = false;
        _interfaceHolder.ShowMenu(MenuType.HUD);
    }
    #endregion

    #region Game
    public void EndMenu()
    {
        Stop();
        _interfaceHolder.ShowMenu(MenuType.EndMenu);
    }

    public void RestartGame()
    {
        Destroy(_map);
        _map = Instantiate(_mapPrefab, Vector3.zero, Quaternion.identity);
        foreach (var player in _players)
        {
            player.ResetPlayer();
        }
        _bombHolder.Clear();
        _playerSwitcher.Restart();
        Play();
        _interfaceHolder.ShowMenu(MenuType.HUD);
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene(_loadMainMenuId);
    }
    #endregion

    private void Play()
    {
        if(_physicSteap != 0)
            Time.timeScale = _physicSteap;
    }

    private void Stop()
    {
        _physicSteap = Time.timeScale;
        Time.timeScale = 0f;
    }
}
