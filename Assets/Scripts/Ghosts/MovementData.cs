using System;
using UnityEngine;

[Serializable]
public class MovementData
{
    [SerializeField][Range(0.1f, 5f)] private float minSpeed = 1f;
    [SerializeField][Range(0.1f, 5f)] private float maxSpeed = 1f;

    public float MinSpeed => minSpeed;
    public float MaxSpeed => maxSpeed;
}
