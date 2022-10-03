using Assets.Scripts.Pool;
using System;
using UnityEngine;
using Zenject;

public class Ghost : MonoBehaviour, IInteractable, IPoolable<Vector3, IMemoryPool>, IDisposable
{
    [SerializeField] private MovementHandler movement;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private IMemoryPool pool;
    private SignalBus signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        this.signalBus = signalBus;
    }

    private void Awake() => spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    private void OnEnable() => movement.SetRandomSpeed();

    private void Update()
    {
        movement.Move(this.transform);

        CheckPositionToDespawn();
    }

    private void SetPosition(Vector3 position)
    {
        position.y -= spriteRenderer.size.y;

        transform.position = position;
    }

    public void Interact()
    {
        signalBus.Fire<GhostKilledSignal>();
        pool.Despawn(this);
    }

    private void CheckPositionToDespawn()
    {
        Vector3 destinationPosition = new Vector3(0, 6, 0);

        if (transform.position.y > destinationPosition.y)
        {
            pool.Despawn(this);
        }
    }

    public void OnDespawned()
    {
        signalBus.Fire<GhostDespawnedSignal>();
        pool = null;
    }

    public void OnSpawned(Vector3 spawnPosition, IMemoryPool pool)
    {
        this.pool = pool;

        SetPosition(spawnPosition);
    }

    public void Dispose()
    {
        pool.Despawn(this);
    }
}