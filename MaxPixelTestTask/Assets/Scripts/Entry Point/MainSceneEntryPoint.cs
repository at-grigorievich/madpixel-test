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

        public MainSceneEntryPoint(IInputService inputService, ZombieController zombieController)
        {
            _inputService = inputService;

            _zombieController = zombieController;
        }

        public void Start()
        {
            _inputService.SetActive(true);
            _zombieController.SetActive(true);
        }

        public void Dispose()
        {

        }
    }
}