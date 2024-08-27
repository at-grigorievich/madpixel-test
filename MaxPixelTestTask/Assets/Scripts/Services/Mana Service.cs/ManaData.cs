using UnityEngine;

namespace ATG.Mana
{
    [CreateAssetMenu(menuName = "configs/mana-data", fileName = "new-mana-data")]
    public sealed class ManaData : ScriptableObject
    {
        [field: SerializeField] public float MaxValue { get; private set; }
        [field: SerializeField] public float ResetSpeed { get; private set; }
    }
}