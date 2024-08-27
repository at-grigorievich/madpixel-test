using ATG.Activator;
using UnityEngine;

namespace ATG.UserInterface
{
    [RequireComponent(typeof(Canvas))]
    public abstract class UIElement : MonoBehaviour, IActivateable
    {
        protected Canvas _canvas;

        public bool IsActive { get; private set; }

        public abstract UIElementType Type { get; }

        protected void Awake()
        {
            _canvas = GetComponent<Canvas>();
            SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            if (_canvas != null)
            {
                _canvas.enabled = isActive;
            }

            IsActive = isActive;
        }

        public virtual void Show()
        {
            SetActive(true);
        }

        public virtual void Hide()
        {
            SetActive(false);
        }
    }
}