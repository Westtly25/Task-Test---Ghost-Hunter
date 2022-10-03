using System;
using UnityEngine;

[Serializable]
public struct SpawnerData
{
    [SerializeField]
    [Min(5)]
    private int amountOnScreenSameTime;

    public int AmountOnScreenSameTime => amountOnScreenSameTime;
}
