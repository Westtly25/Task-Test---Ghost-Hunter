using System;
using UnityEngine;

[Serializable]
public class MovementHandler
{
    [SerializeField] private MovementData movementData;

    private float speed;

    public void SetRandomSpeed()
    {
        speed = UnityEngine.Random.Range(movementData.MinSpeed, movementData.MaxSpeed);
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}