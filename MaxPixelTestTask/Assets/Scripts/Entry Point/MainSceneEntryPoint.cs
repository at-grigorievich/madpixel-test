using System;
using ATG.Equipment;
using ATG.Input;
using ATG.MVC;
using VContainer.Unity;

namespace ATG.Entry
{
    public sealed class MainSceneEntryPoint : IStartable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly ZombieController _zombieController;
        private readonly ChestController _chestController;

        private UILocator _uiLocator;

        private readonly VisualEquipmentService _visualEquipmentService;

        public MainSceneEntryPoint(IInputService inputService, UILocator uILocator, ZombieController zombieController, 
            ChestController chestController, VisualEquipmentService visualEquipmentService)
        {
            _inputService = inputService;

            _zombieController = zombieController;
            _chestController = chestController;

            _visualEquipmentService = visualEquipmentService;

            _uiLocator = uILocator;
        }

        public void Start()
        {
            _visualEquipmentService.SetActive(true);

            _inputService.SetActive(true);
            _zombieController.SetActive(true);
            _chestController.SetActive(true);

            _uiLocator.ShowByType(UserInterface.UIElementType.Main);
        }

        public void Dispose()
        {
            _visualEquipmentService.Dispose();
            _uiLocator.Dispose();
        }
    }
}