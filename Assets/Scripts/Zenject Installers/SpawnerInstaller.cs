using Assets.Scripts.Pool;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class SpawnerInstaller : MonoInstaller
{
    [Header("Components")]
    [SerializeField] private Spawner spawner;

    [Header("Prefabs")]
    [SerializeField] private Ghost enemyPrefab;

    public override void InstallBindings()
    {
        Container.Bind<ISpawner>().FromInstance(spawner).AsSingle().NonLazy();

        Container.BindFactory<Vector3, Ghost, GhostFactory>()
                 .FromPoolableMemoryPool<Vector3, Ghost, GhostPool>(poolBinder => poolBinder
                 .WithInitialSize(10)
                 .FromComponentInNewPrefab(enemyPrefab)
                 .UnderTransformGroup("Spawned Ghosts"));
    }
}