using Assets.Scripts.Pool;
using Zenject;

public class SignalsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GhostKilledSignal>();
        Container.DeclareSignal<GhostDespawnedSignal>();
    }
}