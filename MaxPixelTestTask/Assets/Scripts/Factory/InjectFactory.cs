using IContainerBuilder = VContainer.IContainerBuilder;

namespace ATG.Factory
{
    public abstract class InjectFactory
    {
        public abstract void CreateAndInject(IContainerBuilder builder);
    }
}