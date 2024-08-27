using ATG.Observable;
using UnityEngine;
using VContainer.Unity;

namespace ATG.Mana
{
    public class ManaService : IManaService, ITickable
    {
        private readonly ManaData _config;

        public float MaxValue => _config.MaxValue;

        public IObservableVar<float> CurrentValue { get; private set; }

        public bool IsActive { get; private set; }

        public ManaService(ManaData config)
        {
            _config = config;

            CurrentValue = new ObservableVar<float>(_config.MaxValue);
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;
        }

        public void AddMana(float AddValue)
        {
            if(IsActive == false) return;
            if(AddValue <= 0f) return;

            float nextValue = Mathf.Clamp(CurrentValue.Value + AddValue, 0f, MaxValue);
            CurrentValue.Value = nextValue;
        }

        public bool TryUseMana(float needMana)
        {
            if (IsActive == false) return false;

            if (CurrentValue.Value >= needMana)
            {
                CurrentValue.Value -= needMana;
                return true;
            }
            return false;
        }

        public void Tick()
        {
            if (IsActive == false) return;
            ResetMana();
        }

        public void ResetMana()
        {
            if (CurrentValue.Value >= MaxValue) return;

            float nextValue = Mathf.Clamp(CurrentValue.Value + _config.ResetSpeed * Time.deltaTime, 0f, MaxValue);

            CurrentValue.Value = nextValue;
        }
    }
}