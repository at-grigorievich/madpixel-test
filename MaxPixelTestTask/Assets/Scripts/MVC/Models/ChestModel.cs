using UnityEngine;

namespace ATG.MVC
{
    [CreateAssetMenu(menuName = "configs/models/chest-model", fileName = "chest-model")]
    public sealed class ChestModel : ScriptableObject
    {
        [field: Header("Poke animation params")]
        [field: SerializeField] public AnimationCurve PokeScaleSize { get; private set; }
        [field: SerializeField] public float PokeSpeed { get; private set; }
        [field: SerializeField] public bool UseVFXOnFinish { get; private set; }
    }
}