using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    private void Awake()
    {
        EventAggregator.SpaceObjectDied.Subscribe(LoadDeathScreen);
    }
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
        Debug.Log("Exit - � ��������� �� ���������");
        Application.Quit();
    }

    public void PlayMenuSound()
    {
        SoundManager.Instance.PlaySound("ButtonClick");
    }

    public void StopMusic()
    {
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic("BattleMusic");
        
    }
}
