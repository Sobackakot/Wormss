using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : UIMenu
{
    [SerializeField] private int _singleScene;
    [SerializeField] private int _pvpScene;

    public void LoadSingleScene()
    {
        SceneManager.LoadScene(_singleScene);
    }

    public void LoadPVPScene()
    {
        SceneManager.LoadScene(_pvpScene);
    }
}
