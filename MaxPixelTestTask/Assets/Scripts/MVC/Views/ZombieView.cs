using ATG.Equipment;
using UnityEngine;

namespace ATG.MVC
{
    public sealed class ZombieView : View, IEquipmentService
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Renderer shovelRenderer;
        [Space(5)]
        [SerializeField] private GameObject equipmentTarget;

        [field: SerializeField] public float ManaUsed;

        private IEquipmentService _equipmentService;

        public EquipmentData CurrentEquipment => _equipmentService.CurrentEquipment;

        private void Awake()
        {
            _equipmentService = new EquipmentService(equipmentTarget);
        }

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            _equipmentService.SetActive(isActive);
            
            foreach (var renderer in renderers)
            {
                renderer.enabled = isActive;
            }
        }

        public void SetShovelRendererEnable(bool enable) => shovelRenderer.enabled = enable;

        #region  IEquipmentService referenced
        public void Equip(EquipmentData equipmentConfig) => _equipmentService.Equip(equipmentConfig);
        public void ClearAll() => _equipmentService.ClearAll();
        #endregion

    }
}