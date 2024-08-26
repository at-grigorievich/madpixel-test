using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace ATG.Animation
{
    public sealed class AnimatorService : IAnimatorService
    {
        private readonly Animator _animator;
        private readonly Rig _ikRig;

        private readonly IAnimatorCallback _animatorCallback;

        private readonly AnimatorData _config;

        public bool IsActive { get; private set; }

        public event Action<AnimationType> OnAnimationEventHandled;

        public event EventHandler<string> OnAnimatorReceived
        {
            add => _animatorCallback.OnAnimatorReceived += value;
            remove => _animatorCallback.OnAnimatorReceived -= value;
        }

        public AnimatorService(Animator animator, Rig ikRig, IAnimatorCallback animatorCallback, AnimatorData config)
        {
            _animator = animator;
            _ikRig = ikRig;
            _animatorCallback = animatorCallback;
            _config = config;
        }

        public void PlayCrossfade(AnimationType animationType, float? customFadeTime = null)
        {
            if (IsActive == false) return;

            AnimationData data = _config.GetAnimationDataByType(animationType);

            float duration = customFadeTime.HasValue ? customFadeTime.Value : data.Duration;

            _animator.CrossFade(data.Name, duration);
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;

            _animator.enabled = isActive;
        }

        public void SetIKRigWeight(float weight)
        {
            _ikRig.weight = Mathf.Clamp01(weight);
        }
    }
}