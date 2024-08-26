using System;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace ATG.Animation
{
    [Serializable]
    public sealed class AnimatorCreator
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimatorCallbackService callbackService;
        [SerializeField] private Rig IKRig;
        [Space(10)]
        [SerializeField] private AnimatorData config;

        public IAnimatorService Create()
        {
            return new AnimatorService
            (
                animator: animator,
                ikRig: IKRig,
                animatorCallback: callbackService,
                config: config
            );
        }
    }
}