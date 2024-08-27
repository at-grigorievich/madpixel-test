using System;

namespace ATG.MVC
{
    public sealed class ChestController : Controller<ChestView>
    {
        public ChestController(ChestView view) : base(view)
        {
        }

        public void AnimatePokePunch(Action callback = null) => _view.AnimatePokePunch(callback);
    }
}