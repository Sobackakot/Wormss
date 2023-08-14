using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIMenu
{
    [SerializeField] private int _loadId;

    public void LoadScene()
    {
        SceneManager.LoadScene(_loadId);
    }
}
