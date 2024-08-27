using ATG.Animation;
using ATG.Equipment;
using ATG.Input;
using ATG.Observable;
using ATG.StateMachine;
using VContainer;
using VContainer.Unity;

using SM = ATG.StateMachine.StateMachine;

namespace ATG.MVC
{
    public sealed class ZombieController : Controller<ZombieView>, ITickable, IEquipmentService
    {
        private readonly IAnimatorService _animatorService;

        private readonly SM _sm;

        public EquipmentData CurrentEquipment => _view.CurrentEquipment;

        public ZombieController(IObjectResolver resolver, ZombieView view) : base(view)
        {
            _animatorService = resolver.Resolve<IAnimatorService>();

            var inputService = resolver.Resolve<IInputService>();
            var chestController = resolver.Resolve<ChestController>();

            var uiLocator = resolver.Resolve<UILocator>();
            var messageBroker = resolver.Resolve<IMessageBroker>();

            _sm = new SM();

            _sm.AddStatementsRange
            (
                new ZombieIdleState(inputService, _animatorService, _view, _sm),
                new ZombieDigState(messageBroker, uiLocator, _animatorService, chestController, _view, _sm)
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

        #region  IEquipmentService referenced
        public void Equip(EquipmentData equipmentConfig) => _view.Equip(equipmentConfig);
        public void ClearAll() => _view.ClearAll();
        #endregion
    }
}