using Jobfinding.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace Jobfinding.Data.ViewComponents
{
    public class ApplyCartSummary:ViewComponent
    {
        private readonly ApplyCart _applyCart;
        public ApplyCartSummary(ApplyCart applyCart)
        {
            _applyCart = applyCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _applyCart.GetApplyCartItems();

            return View(items.Count);
        }
    }
}

