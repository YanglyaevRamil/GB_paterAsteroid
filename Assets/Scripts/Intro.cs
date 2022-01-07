using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
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
