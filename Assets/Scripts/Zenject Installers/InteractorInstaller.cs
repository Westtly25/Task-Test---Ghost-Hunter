using Assets.Scripts.Interaction;
using Zenject;

public class InteractorInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Interactor>().FromNew().AsSingle();
    }
}