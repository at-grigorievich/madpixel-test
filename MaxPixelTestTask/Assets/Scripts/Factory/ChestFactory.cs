using System;
using ATG.MVC;
using UnityEngine;
using VContainer;

namespace ATG.Factory
{
    [Serializable]
    public sealed class ChestFactory: InjectFactory
    {
        [SerializeField] private ChestView view;

        public override void CreateAndInject(IContainerBuilder builder)
        {
            builder.Register<ChestController>(Lifetime.Singleton)
                .WithParameter<ChestView>(view);
        }
    }
}
