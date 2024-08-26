using System;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace ATG.Input
{
    public sealed class InputService : IInputService, ITickable
    {
        private readonly SimplyInput _input;

        public bool IsActive { get; private set; }

        public event Action<InputType> OnInputInvoke;

        public InputService()
        {
            _input = new SimplyInput();
        }

        public void SetActive(bool isActive)
        {
            IsActive = isActive;

            if (IsActive == true)
            {
                _input.Enable();
                _input.Base.Click.performed += OnClickHandled;
            }
            else
            {
                _input.Disable();
                _input.Base.Click.performed -= OnClickHandled;
            }
        }

        public bool IsInputPerformedByType(InputType inputType)
        {
            InputAction action = inputType switch
            {
                InputType.Click => _input.Base.Click,
                _ => throw new InvalidOperationException($"no input action for {inputType} type"),
            };
            return action.IsInProgress() == true || action.IsPressed() == true;
        }

        public void Tick()
        {
            //todo in future...
            if(IsActive == false) return;
        }

        private void OnClickHandled(InputAction.CallbackContext _)
        {
            OnInputInvoke?.Invoke(InputType.Click);
        }
    }
}