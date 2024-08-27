using ATG.Animation;
using ATG.Input;
using ATG.StateMachine;
using VContainer;
using VContainer.Unity;

using SM = ATG.StateMachine.StateMachine;

namespace ATG.MVC
{
    public sealed class ZombieController : Controller<ZombieView>, ITickable
    {
        private readonly IAnimatorService _animatorService;

        private readonly SM _sm;

        public ZombieController(IObjectResolver resolver, ZombieView view) : base(view)
        {
            _animatorService = resolver.Resolve<IAnimatorService>();

            var inputService = resolver.Resolve<IInputService>();
            var chestController = resolver.Resolve<ChestController>();

            _sm = new SM();

            _sm.AddStatementsRange
            (
                new ZombieIdleState(inputService, _animatorService, _view, _sm),
                new ZombieDigState(_animatorService, chestController, _view, _sm)
            );

            _sm.SwitchState<ZombieIdleState>();
        }

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            _animatorService.SetActive(isActive);

            _sm.PauseMachine();

            if (IsActive == true)
            {
                _sm.StartOrContinueMachine();
            }
        }

        public void Tick()
        {
            if (IsActive == false) return;
            _sm.ExecuteMachine();
        }
    }
}