using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private GameObject spaceShipPrefab;
    private void Awake()
    {
        spaceShipPrefab = Resources.Load<GameObject>("");
    }
}
