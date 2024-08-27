using System;
using ATG.Factory;
using UnityEngine;
using VContainer;

namespace ATG.Mana
{
    [Serializable]
    public sealed class ManaServiceCreator: InjectFactory
    {
        [SerializeField] private ManaData config;

        public override void CreateAndInject(IContainerBuilder builder)
        {
            builder.Register<ManaService>(Lifetime.Singleton)
                .WithParameter<ManaData>(config)
                .AsImplementedInterfaces();
        }
    }
}