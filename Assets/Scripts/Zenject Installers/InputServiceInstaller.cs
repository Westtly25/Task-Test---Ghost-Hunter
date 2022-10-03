using Assets.Scripts.Interaction;
using Zenject;

public class InputServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputService>().FromNew().AsSingle().NonLazy();
    }
}