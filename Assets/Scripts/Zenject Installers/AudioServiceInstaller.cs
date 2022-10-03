using Assets.Scripts.Audio_System;
using Zenject;
using UnityEngine;

public class AudioServiceInstaller : MonoInstaller
{
    [SerializeField] private AudioService audioService;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<AudioService>().FromInstance(audioService).AsSingle().NonLazy();
    }
}