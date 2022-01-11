using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptIntro : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SwitchScene());
    }
    IEnumerator SwitchScene()
    {
        yield return new WaitForSecondsRealtime(13f);
        SceneManager.LoadScene("Menu");
    }
}
