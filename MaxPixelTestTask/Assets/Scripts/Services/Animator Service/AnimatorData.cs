using System;
using UnityEngine;

namespace ATG.Animation
{
    [Serializable]
    public sealed class AnimationData
    {
        [field: SerializeField] public AnimationType Type { get; private set; }
        [field: SerializeField] public string Name {get; private set;}
        [field: SerializeField] public float Duration {get; private set;}= 0.02f;
    }

    [CreateAssetMenu(menuName = "configs/animator", fileName = "new-animator-config")]
    public sealed class AnimatorData: ScriptableObject
    {
        [SerializeField] private AnimationData[] animations;

        public AnimationData GetAnimationDataByType(AnimationType animationType)
        {
            var result = Array.Find(animations, animData => animData.Type == animationType);

            if(result == null)
                throw new NullReferenceException($"Can't find animation data with type {animationType}");

            return result;
        }
    }
}