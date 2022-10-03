using UnityEngine;
using Zenject;

public class SceneServiceInstaller : MonoInstaller
{
    [SerializeField] private SceneLoaderService sceneService;

    public override void InstallBindings()
    {
        Container.Bind<ISceneLoaderService>().FromComponentInNewPrefab(sceneService).AsSingle().NonLazy();
    }
}