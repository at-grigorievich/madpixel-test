using ATG.Activator;
using UnityEngine;

namespace ATG.MVC
{
    public abstract class View : ActivateBehaviour
    {
        public void SetParent(Transform parent, bool resetToZero)
        {
            transform.SetParent(parent);

            transform.localRotation = Quaternion.identity;

            if (resetToZero == false) return;

            transform.localPosition = Vector3.zero;
        }

        public void SetParent(Transform parent, Vector3 localPosition, Quaternion localRotation)
        {
            transform.SetParent(parent);
            transform.localPosition = localPosition;
            transform.localRotation = localRotation;
        }

        public void SetLayer(int layerIndex)
        {
            if(gameObject == null) return;
            gameObject.layer = layerIndex;
        }
    }
}