using System;
using ATG.Activator;

namespace ATG.Animation
{
    public interface IAnimatorService: IActivateable
    {
        event EventHandler<string> OnAnimatorReceived;
        
        void PlayCrossfade(AnimationType animationType, float? customFadeTime = null);
        void SetIKRigWeight(float weight);
    }
}