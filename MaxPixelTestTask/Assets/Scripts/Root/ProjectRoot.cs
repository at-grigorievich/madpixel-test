using ATG.Entry;
using ATG.Input;
using ATG.Observable;
using VContainer;
using VContainer.Unity;

namespace ATG.Root
{
    public sealed class ProjectRoot: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputService>(Lifetime.Singleton)
                .As<IInputService>()
                .As<ITickable>();

            builder.Register<IMessageBroker, WorldMessageBroker>(Lifetime.Singleton);

            builder.RegisterEntryPoint<ProjectEntryPoint>(Lifetime.Singleton);
        }
    }
}