using ATG.Animation;
using ATG.Messages;
using ATG.MVC;
using ATG.Observable;

namespace ATG.StateMachine
{
    public sealed class ZombieDigState : Statement
    {
        private readonly ZombieView _zombieView;

        private readonly IAnimatorService _animatorService;
        private readonly UILocator _uiLocator;

        private readonly IMessageBroker _messageBroker;

        private readonly ChestController _chest;

        private ObserveDisposable _dis;

        public ZombieDigState(IMessageBroker worldMessageBroker, UILocator uiLocator, IAnimatorService animatorService, ChestController chest, 
            ZombieView view, IStateSwitcher sw) : base(sw)
        {
            _zombieView = view;
            _animatorService = animatorService;

            _messageBroker = worldMessageBroker;
            _uiLocator = uiLocator;

            _chest = chest;
        }

        public override void Enter()
        {
            _animatorService.SetIKRigWeight(0.9f);
            _animatorService.PlayCrossfade(AnimationType.Dig);
            _zombieView.SetShovelRendererEnable(true);

            _animatorService.OnAnimatorReceived += OnAnimatorReceived;

            _dis = _messageBroker.Subscribe<CompleteDiggingMessage>(OnCompleteDiggingMessage);
        }

        public override void Exit()
        {
            _animatorService.OnAnimatorReceived -= OnAnimatorReceived;
            _dis?.Dispose();
        }

        public override void Execute()
        {

        }

        private void OnAnimatorReceived(object sender, string animatorEventName)
        {
            if(animatorEventName == AnimatorCallbackService.CompleteDig)
            {
                FinishDiggingAnimation();
            }
            else if(animatorEventName == AnimatorCallbackService.InteractDig)
            {
                InteractWithChest();
            }
        }

        private void FinishDiggingAnimation()
        {
            _uiLocator.ShowByType(UserInterface.UIElementType.EquipmentDrop);
        }

        private void InteractWithChest()
        {
            _chest.AnimatePokePunch();
        }
    
        private void OnCompleteDiggingMessage(IMessage msg)
        {
            _stateSwitcher.SwitchState<ZombieIdleState>();
        }
    }
}