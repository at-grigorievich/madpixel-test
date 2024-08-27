using UnityEngine;

namespace ATG.Equipment
{
    [CreateAssetMenu(menuName = "configs/equipment/new equipment", fileName = "new-equipment")]
    public sealed class EquipmentData : ScriptableObject
    {
        [field: Header("Main")]
        [field: SerializeField] public string Name {get; private set;}
        [field: SerializeField] public int SellManaCost {get; private set;}

        [field: Header("Mesh")]
        [field: SerializeField] public Mesh Mesh { get; private set; }
        [field: SerializeField] public Material[] Materials { get; private set; }
        [field: SerializeField] public Vector3 LocalPosition { get; private set; }
        [field: SerializeField] public Vector3 LocalEulerAngles { get; private set; }
        [field: SerializeField] public Vector3 LocalScale { get; private set; }

        [field: Header("UI Parameters")]
        [field: SerializeField] public float ZoomValue { get; private set; } = 60f;
        [field: SerializeField] public Vector3 RectPosition { get; private set; }
    }
}