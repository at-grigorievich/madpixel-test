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

        private readonly VisualEquipmentService _visualEquipmentService;

        public MainSceneEntryPoint(IInputService inputService, ZombieController zombieController, 
            ChestController chestController, VisualEquipmentService visualEquipmentService)
        {
            _inputService = inputService;

            _zombieController = zombieController;
            _chestController = chestController;

            _visualEquipmentService = visualEquipmentService;
        }

        public void Start()
        {
            _visualEquipmentService.SetActive(true);

            _inputService.SetActive(true);
            _zombieController.SetActive(true);
            _chestController.SetActive(true);
        }

        public void Dispose()
        {
            _visualEquipmentService.SetActive(false);
        }
    }
}