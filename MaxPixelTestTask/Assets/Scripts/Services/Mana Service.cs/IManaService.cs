using ATG.Activator;
using ATG.Observable;

namespace ATG.Mana
{
    public interface IManaService : IActivateable
    {
        float MaxValue { get; }
        IObservableVar<float> CurrentValue { get; }

        public void AddMana(float AddValue);
        public bool TryUseMana(float needMana);
    }
}