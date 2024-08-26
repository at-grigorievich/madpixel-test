using UnityEngine;

namespace ATG.MVC
{
    public sealed class ZombieView: View
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Renderer shovelRenderer;

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            foreach(var renderer in renderers)
            {
                renderer.enabled = isActive;
            }
        }

        public void SetShovelRendererEnable(bool enable) => shovelRenderer.enabled = enable;
    }
}