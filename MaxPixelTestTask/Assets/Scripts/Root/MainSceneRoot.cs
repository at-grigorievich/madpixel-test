using ATG.Entry;
using ATG.Factory;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ATG.Root
{
    public sealed class MainSceneRoot: LifetimeScope
    {
        [SerializeField] private ZombieFactory zombieFactory;

        protected override void Configure(IContainerBuilder builder)
        {
            zombieFactory.CreateAndInject(builder);

            builder.RegisterEntryPoint<MainSceneEntryPoint>(Lifetime.Singleton);
        }
    }
}