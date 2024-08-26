using System;
using ATG.Input;
using ATG.Observable;
using VContainer.Unity;

namespace ATG.Entry
{
    public sealed class ProjectEntryPoint: IStartable, IDisposable
    {
        private readonly IMessageBroker _msgBroker;
        private readonly IInputService _inputService;

        public ProjectEntryPoint(IMessageBroker msgBroker, IInputService inputService)
        {
            _msgBroker = msgBroker;
            _inputService = inputService;
        }

        public void Start()
        {
            _inputService.SetActive(false);
        }

        public void Dispose()
        {
            _inputService.SetActive(false);
        }
    }
}