using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    public void LoadNewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadRetry()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }
    public void LoadDeathScreen(SpaceObject spaceObject)
    {
        if (spaceObject is SpaceShip)
            SceneManager.LoadScene("DeathScreen");
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
