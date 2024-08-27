using System;
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

        public MainSceneEntryPoint(IInputService inputService, ZombieController zombieController, ChestController chestController)
        {
            _inputService = inputService;

            _zombieController = zombieController;
            _chestController = chestController;
        }

        public void Start()
        {
            _inputService.SetActive(true);
            _zombieController.SetActive(true);
            _chestController.SetActive(true);
        }

        public void Dispose()
        {

        }
    }
}