using Assets.Scripts.Interaction;
using Assets.Scripts.Pool;
using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class Counter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        
        private int countValue = 0;

        private SignalBus signalBus;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        private void Awake()
        {
            textMesh = GetComponent<TextMeshProUGUI>();
            ResetValue();
        }

        private void OnEnable() => signalBus.Subscribe<GhostKilledSignal>(UpdateValue);

        private void OnDisable() => signalBus.Unsubscribe<GhostKilledSignal>(UpdateValue);

        private void UpdateValue()
        {
            countValue++;

            textMesh.text = $"Ghosts : {countValue}";
        }

        private void ResetValue()
        {
            countValue = 0;
            textMesh.text = $"Ghosts : {countValue}";
        }
    }
}