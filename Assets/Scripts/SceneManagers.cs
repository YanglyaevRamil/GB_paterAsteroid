using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene(SceneType.GameScene);
    }

    public void LoadRetry()
    {
        SceneManager.LoadScene(SceneType.GameScene);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneType.MenuScene);
        
    }

    public void LoadDeathScreen(SpaceObject spaceObject)
    {
        if (spaceObject is SpaceShip)
            SceneManager.LoadScene(SceneType.DeathScreenScene);
    }

    public void LoadExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
