using ATG.Mana;
using ATG.Observable;
using UnityEngine;
using VContainer;

namespace ATG.UserInterface
{
    public sealed class MainView : UIElement
    {
        [SerializeField] private ProgressBar progressBar;

        [Inject] private IManaService _manaService;

        private ObserveDisposable _dis;

        public override UIElementType Type => UIElementType.Main;

        public override void Show()
        {
            base.Show();

            _dis = _manaService.CurrentValue.Subscribe(OnManaChanged);
            OnManaChanged(_manaService.CurrentValue.Value);
        }

        public override void Hide()
        {
            base.Hide();

            _dis?.Dispose();
            _dis = null;
        }

        private void OnManaChanged(float currentMana)
        {
            progressBar.UpdateProgress(currentMana, _manaService.MaxValue);
        }
    }
}