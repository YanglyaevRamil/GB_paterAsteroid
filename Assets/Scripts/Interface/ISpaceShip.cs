using UnityEngine;

public interface ISpaceShip : IMoving, IRotation, IDead
{
    int Damage { get; }
}
