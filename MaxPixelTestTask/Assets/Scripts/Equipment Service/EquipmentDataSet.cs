using System;
using UnityEngine;

namespace ATG.Equipment
{
    [CreateAssetMenu(menuName = "configs/equipment/new equipments set", fileName = "new-equipment-set")]
    public sealed class EquipmentDataSet : ScriptableObject
    {
        [SerializeField] private EquipmentData[] equipments;

        public EquipmentData GetDataByIndex(int index)
        {
            if(index < 0 || index >= equipments.Length)
                throw new IndexOutOfRangeException($"no equipments with index={index}");

            return equipments[index];
        }

        public EquipmentData GetRndData()
        {
            int random = UnityEngine.Random.Range(0, equipments.Length);
            return equipments[random];
        }
    }
}