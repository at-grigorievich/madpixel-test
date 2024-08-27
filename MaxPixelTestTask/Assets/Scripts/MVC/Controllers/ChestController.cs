namespace ATG.MVC
{
    public sealed class ChestController : Controller<ChestView>
    {
        public ChestController(ChestView view) : base(view)
        {
        }

        public void AnimatePokePunch() => _view.AnimatePokePunch();
    }
}