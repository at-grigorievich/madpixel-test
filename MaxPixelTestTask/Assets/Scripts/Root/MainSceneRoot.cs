using ATG.Entry;
using ATG.Equipment;
using ATG.Factory;
using ATG.Mana;
using ATG.UserInterface;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ATG.Root
{
    public sealed class MainSceneRoot: LifetimeScope
    {
        [SerializeField] private ZombieFactory zombieFactory;
        [SerializeField] private ChestFactory chestFactory;
        [SerializeField] private VisualEquipmentServiceFactory visualEquipmentServiceFactory;
        [SerializeField] private UILocatorCreator uiLocatorCreator;
        [SerializeField] private ManaServiceCreator manaServiceCreator;
        [SerializeField] private EquipmentDataSet equipmentDataSet;

        protected override void Configure(IContainerBuilder builder)
        {
            zombieFactory.CreateAndInject(builder);
            chestFactory.CreateAndInject(builder);
            visualEquipmentServiceFactory.CreateAndInject(builder);
            uiLocatorCreator.CreateAndInject(builder);
            manaServiceCreator.CreateAndInject(builder);

            builder.RegisterInstance(equipmentDataSet);

            builder.RegisterEntryPoint<MainSceneEntryPoint>(Lifetime.Singleton);
        }
    }
}