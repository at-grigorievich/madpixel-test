using System;

namespace ATG.Animation
{
    public interface IAnimatorCallback
    {
        event EventHandler<string> OnAnimatorReceived;
    }
}