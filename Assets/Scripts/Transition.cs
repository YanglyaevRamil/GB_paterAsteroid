using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject transition;

    private void Start()
    {
        StartCoroutine(Introend());
    }

    IEnumerator Introend()
    {
        yield return new WaitForSecondsRealtime(0.8f);
        transition.SetActive(false);
    }
}
