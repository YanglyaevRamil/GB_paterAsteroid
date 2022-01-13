using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStoneMoving : IMoving
{
    public float speed { set; get; }
    private Transform transformSpaceStone;
    private Vector3 normVecdMoment;
    public SpaceStoneMoving(Transform transformSpaceStone, Transform transformShip, float speed)
    {
        this.transformSpaceStone = transformSpaceStone;
        this.speed = speed;

        normVecdMoment = (transformShip.position - transformSpaceStone.position) / (transformShip.position - transformSpaceStone.position).magnitude;
    }
    public void Moving()
    {
        transformSpaceStone.position += normVecdMoment * speed;
    }
}
