using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ATG.UserInterface
{
    [RequireComponent(typeof(RectTransform))]
    public class ScaleButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {  
        [SerializeField] private Vector3 clickScale;

        private RectTransform _rect;

        private Vector3 _defaultScale;

        public event Action OnClick;

        private void Awake()
        {
            _rect = GetComponent<RectTransform>();
            _defaultScale = _rect.localScale;
        }

        private void OnDisable()
        {
            _rect.localScale = _defaultScale;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _rect.localScale = _defaultScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _rect.localScale = clickScale;
        }
    }
}