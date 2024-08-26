using System;
using ATG.Animation;
using ATG.MVC;
using UnityEngine;
using VContainer;

namespace ATG.Factory
{
    [Serializable]
    public sealed class ZombieFactory: InjectFactory
    {
        [SerializeField] private ZombieView zombieView;
        [SerializeField] private AnimatorCreator animatorCreator;

        public override void CreateAndInject(IContainerBuilder builder)
        {
            builder.RegisterInstance(animatorCreator.Create())
                .As<IAnimatorService>();
            
            builder.Register<ZombieController>(Lifetime.Singleton)
                .WithParameter<ZombieView>(zombieView)
                .AsSelf().AsImplementedInterfaces();
        }
    }
}