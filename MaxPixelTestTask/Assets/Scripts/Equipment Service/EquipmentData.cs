using UnityEngine;

namespace ATG.Equipment
{
    [CreateAssetMenu(menuName = "configs/equipment/new equipment", fileName = "new-equipment")]
    public sealed class EquipmentData : ScriptableObject
    {
        [field: SerializeField] public Mesh Mesh { get; private set; }
        [field: SerializeField] public Material[] Materials { get; private set; }
        [field: SerializeField] public Vector3 LocalPosition { get; private set; }
        [field: SerializeField] public Vector3 LocalEulerAngles { get; private set; }
        [field: SerializeField] public Vector3 LocalScale { get; private set; }
    }
}