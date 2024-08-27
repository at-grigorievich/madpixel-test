using System;
using ATG.Activator;

namespace ATG.Input
{
    public enum InputType: byte
    {
        None = 0,
        Click = 1
    }

    public interface IInputService: IActivateable
    {
        public event Action<InputType> OnInputInvoke;

        bool IsInputPerformedByType(InputType inputType);
    }
}
