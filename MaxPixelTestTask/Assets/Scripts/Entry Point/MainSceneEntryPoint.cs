using System;
using ATG.Input;
using VContainer.Unity;

namespace ATG.Entry
{
    public sealed class MainSceneEntryPoint : IStartable, IDisposable
    {
        private readonly IInputService _inputService;

        public MainSceneEntryPoint(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Start()
        {
            _inputService.SetActive(true);
        }

        public void Dispose()
        {

        }
    }
}