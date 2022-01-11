using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private void Awake()
    {
        score = 0;
        EventAggregator.SpaceObjectDied.Subscribe(OnAsteroidtDied);
    }

    private void OnAsteroidtDied(SpaceObject asteroid)
    {
        if (asteroid as Asteroid)
        {
            score += 1;
        }
    }
}
