using Jobfinding.Data.Cart;
using Jobfinding.Data.Services;
using Jobfinding.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Jobfinding.Controllers
{

    public class ApplysController : Controller
    {
        private readonly IFindjobsServices _findjobsService;
        private readonly ApplyCart _applyCart;
        private readonly IApplysService _applysService;


        public ApplysController(IFindjobsServices findjobsService, ApplyCart applyCart, IApplysService applysService)
        {
            _findjobsService = findjobsService;
            _applyCart = applyCart;
            _applysService = applysService;
        }

        public IActionResult ApplyCart()
        {
            var items = _applyCart.GetApplyCartItems();
            _applyCart.ApplyCartItems = items;

            var response = new ApplyCartVM()
            {
                ApplyCart = _applyCart,
                ApplyCartTotal = _applyCart.GetApplyCartTotal()
            };
            return View(response);
        }
        public async Task<IActionResult> AddItemToApplyCart(int id)
        {
            var item = await _findjobsService.GetFindjobsByIdAsync(id);

            if (item != null)
            {
                _applyCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ApplyCart));
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var applys = await _applysService.GetApplysByUserIdAndRoleAsync(userId,userRole);
            return View(applys);
        }


        public async Task<IActionResult> RemoveItemFromApplyCart(int id)
        {
            var item = await _findjobsService.GetFindjobsByIdAsync(id);

            if (item != null)
            {
                _applyCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ApplyCart));
        }
        public async Task<IActionResult> CompleteApply()
        {
            var items = _applyCart.GetApplyCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _applysService.StoreApplyAsync(items, userId, userEmailAddress);
            await _applyCart.ClearApplyCartAsync();

            return View("ApplyCompleted");
        }


    }

}