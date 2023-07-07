using Jobfinding.Data;
using Jobfinding.Data.Services;
using Jobfinding.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Controllers
{
    public class CompanysController : Controller
    {
        private readonly ICompanysService _service;
        public CompanysController(ICompanysService service)
        {
            _service=service;
        }
        public async Task<IActionResult> Index()
        {
            var allCompanies =await  _service.GetAllAsync();
            return View(allCompanies);
        }

        //company detail

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);
            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        //create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageURL,Info")] Company company)
        {
            if (ModelState.IsValid)
            {
                return View(company);
            }
            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));

        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("NotFound");

            return View(companyDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageURL,Info")] Company company)
        {
            if (ModelState.IsValid)
            {
                return View(company);
            }
            await _service.UpdateAsync(id, company);
            return RedirectToAction(nameof(Index));

        }
        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("NotFound");

            return View(companyDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
