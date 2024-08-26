using ATG.Animation;
using ATG.MVC;

namespace ATG.StateMachine
{
    public sealed class ZombieDigState : Statement
    {
        private readonly ZombieView _zombieView;

        private readonly IAnimatorService _animatorService;

        public ZombieDigState(IAnimatorService animatorService, ZombieView view, IStateSwitcher sw) : base(sw)
        {
            _zombieView = view;
            _animatorService = animatorService;
        }

        public override void Enter()
        {
            _animatorService.SetIKRigWeight(0.9f);
            _animatorService.PlayCrossfade(AnimationType.Dig);
            _zombieView.SetShovelRendererEnable(true);

            _animatorService.OnAnimatorReceived += OnDiggingFinishedReceived;
        }

        public override void Exit()
        {
            _animatorService.OnAnimatorReceived -= OnDiggingFinishedReceived;
        }

        public override void Execute()
        {

        }

        private void OnDiggingFinishedReceived(object sender, string e)
        {
            _stateSwitcher.SwitchState<ZombieIdleState>();
        }
    }
}