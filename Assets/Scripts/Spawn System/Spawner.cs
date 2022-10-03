using Assets.Scripts.Helpers;
using Assets.Scripts.Pool;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class Spawner : MonoBehaviour, ISpawner
{
    [SerializeField] private SpawnerData spawnerData;
    public SpawnerData SpawnerData => spawnerData;

    [Header("Injected Components")]
    private GhostFactory ghostFactory;
    private SignalBus signalBus;

    private int activeSpawnedAmount;

    [Inject]
    public void Construct(GhostFactory pool, SignalBus signalBus)
    {
        this.ghostFactory = pool;
        this.signalBus = signalBus;
    }

    private void OnEnable()
    {
        signalBus.Subscribe<GhostDespawnedSignal>(OnDespawned);
    }

    private void OnDisable()
    {
        signalBus.Unsubscribe<GhostDespawnedSignal>(OnDespawned);
    }

    private void Update()
    {
        SpawnGhosts();
    }

    private void OnDespawned()
    {
        activeSpawnedAmount--;
    }

    private void Spawn()
    {
        activeSpawnedAmount++;

        Vector3 randPos = GetRandomPositionToSpawn(CameraBoundsHandler.GetBoundCoordByType(BoundType.LeftBottom),
                                                   CameraBoundsHandler.GetBoundCoordByType(BoundType.RightBottom));
        ghostFactory.Create(randPos);

    }


    private void SpawnGhosts()
    {
        while (activeSpawnedAmount < spawnerData.AmountOnScreenSameTime)
        {
            Spawn();
        }
    }

    private Vector3 GetRandomPositionToSpawn(Vector3 startPos, Vector3 endPos)
    {
        float x = UnityEngine.Random.Range(startPos.x, endPos.x);
        float y = UnityEngine.Random.Range(startPos.y, endPos.y);

        return new Vector3(x, y, 0);
    }
}