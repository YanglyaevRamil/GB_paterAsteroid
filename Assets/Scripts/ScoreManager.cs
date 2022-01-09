using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private void Start()
    {
        score = 0;
        StartCoroutine(ScoreCnt());
    }
    IEnumerator ScoreCnt()
    {
        yield return new WaitForSeconds(1f);
        score++;
        StartCoroutine(ScoreCnt());
    }
}
