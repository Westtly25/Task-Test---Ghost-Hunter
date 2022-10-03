using Assets.Scripts.Audio_System;
using Assets.Scripts.Pool;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Interaction
{
    public class Interactor : IInteractor, IInitializable, IDisposable
    {
        [Header("Injected Components")]
        private IInputService inputManger;
        private IAudioService audioService;

        [Header("Cached Components")]
        [SerializeField] private Camera mainCamera;

        [Inject]
        public Interactor(IInputService inputManger, IAudioService audioService)
        {
            this.inputManger = inputManger;
            this.audioService = audioService;
        }

        public void Initialize()
        {
            Setup();
            Subscribe();
        }
        public void Dispose() => UnSubscribe();

        private void Setup()
        {
            mainCamera = Camera.main;
        }

        private void Subscribe()
        {
            inputManger.OnClickPerformed += Interact;
        }

        private void UnSubscribe()
        {
            inputManger.OnClickPerformed -= Interact;
        }

        private void Interact()
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if(Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
            {
                if (raycastHit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Interact();
                    audioService.PlayAudio(AudioItemType.SoundEffect);
                }
            }
        }
    }
}