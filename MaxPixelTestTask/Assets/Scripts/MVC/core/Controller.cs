using ATG.Activator;
using UnityEngine;

namespace ATG.MVC
{
    public abstract class Controller<T> : ActivateObject where T : View
    {
        protected T _view;

        public Controller(T view)
        {
            _view = view;
        }

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);
            _view.SetActive(isActive);
        }

        public void SetParent(Transform parent, bool resetToZero) =>
                _view.SetParent(parent, resetToZero);

        public void SetParent(Transform parent, Vector3 localPosition, Quaternion localRotation) =>
                _view.SetParent(parent,localPosition, localRotation);

        public void SetLayer(int layerIndex) => _view.SetLayer(layerIndex);

    }
}