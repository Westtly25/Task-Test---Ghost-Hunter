using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Assets.Scripts.Interaction
{
    public class InputService : IInputService, IInitializable, IDisposable
    {
        [Header("Unity Input Data")]
        private GameControls gameControls;
        private InputAction inputAction;

        public event Action OnClickPerformed;

        private void EnableControls()
        {
            gameControls = new GameControls();
            inputAction = gameControls.Player.Click;

            gameControls.Enable();
            inputAction.Enable();

            inputAction.performed += OnClick;
        }

        private void DisableControls()
        {
            gameControls.Disable();
            inputAction.Disable();

            inputAction.performed -= OnClick;
        }

        private void OnClick(InputAction.CallbackContext callbackContext)
        {
            OnClickPerformed?.Invoke();
        }

        public void Initialize()
        {
            EnableControls();
        }

        public void Dispose()
        {
            DisableControls();
        }
    }
}