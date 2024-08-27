using ATG.Activator;

namespace ATG.Equipment
{
    public interface IEquipmentService : IActivateable
    {
        EquipmentData CurrentEquipment { get; }

        public void Equip(EquipmentData equipmentConfig);
        public void ClearAll();
    }
}