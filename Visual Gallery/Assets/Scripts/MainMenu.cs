using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void CutsceneButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void LobbyButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void FullscreenEffectsButtonClick()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelButtonClick()
    {
        SceneManager.LoadScene(4);
    }
}
