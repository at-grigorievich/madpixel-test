using ATG.Animation;
using ATG.MVC;

namespace ATG.StateMachine
{
    public sealed class ZombieDigState : Statement
    {
        private readonly ZombieView _zombieView;

        private readonly IAnimatorService _animatorService;

        private readonly ChestController _chest;

        public ZombieDigState(IAnimatorService animatorService, ChestController chest, ZombieView view, 
            IStateSwitcher sw) : base(sw)
        {
            _zombieView = view;
            _animatorService = animatorService;

            _chest = chest;
        }

        public override void Enter()
        {
            _animatorService.SetIKRigWeight(0.9f);
            _animatorService.PlayCrossfade(AnimationType.Dig);
            _zombieView.SetShovelRendererEnable(true);

            _animatorService.OnAnimatorReceived += OnAnimatorReceived;
        }

        public override void Exit()
        {
            _animatorService.OnAnimatorReceived -= OnAnimatorReceived;
        }

        public override void Execute()
        {

        }

        private void OnAnimatorReceived(object sender, string animatorEventName)
        {
            if(animatorEventName == AnimatorCallbackService.CompleteDig)
            {
                FinishDigging();
            }
            else if(animatorEventName == AnimatorCallbackService.InteractDig)
            {
                InteractDigging();
            }
        }

        private void FinishDigging()
        {
            _stateSwitcher.SwitchState<ZombieIdleState>();
        }

        private void InteractDigging()
        {
            _chest.AnimatePokePunch();
        }
    }
}