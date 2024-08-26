using ATG.Animation;
using ATG.Input;
using ATG.MVC;

namespace ATG.StateMachine
{
    public sealed class ZombieIdleState : Statement
    {
        private readonly ZombieView _zombieView;

        private readonly IAnimatorService _animatorService;
        private readonly IInputService _inputService;

        public ZombieIdleState(IInputService inputService, IAnimatorService animatorService, ZombieView view,
            IStateSwitcher sw) : base(sw)
        {
            _zombieView = view;

            _animatorService = animatorService;

            _inputService = inputService;
        }

        public override void Enter()
        {
            _animatorService.SetIKRigWeight(0f);
            _animatorService.PlayCrossfade(AnimationType.IdleWithDance);
            _zombieView.SetShovelRendererEnable(false);

            _inputService.OnInputInvoke += OnInputInvoked;
        }

        public override void Exit()
        {
            _inputService.OnInputInvoke -= OnInputInvoked;
        }

        public override void Execute()
        {

        }

        private void OnInputInvoked(InputType inputType)
        {
            if(inputType != InputType.Click) return;
            
            _stateSwitcher.SwitchState<ZombieDigState>();
        }
    }
}