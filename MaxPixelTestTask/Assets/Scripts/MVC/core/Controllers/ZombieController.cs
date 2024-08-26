using ATG.Animation;
using VContainer;
using VContainer.Unity;

namespace ATG.MVC
{
    public sealed class ZombieController: Controller<ZombieView>, ITickable
    {
        private readonly IAnimatorService _animatorService;

        public ZombieController(IObjectResolver resolver, ZombieView view): base(view)
        {
            _animatorService = resolver.Resolve<IAnimatorService>();
        }

        public override void SetActive(bool isActive)
        {
            base.SetActive(isActive);

            _animatorService.SetActive(isActive);
        }

        public void Tick()
        {
            if(IsActive == false) return;
        }
    }
}