using Jobfinding.Data;
using Jobfinding.Data.Services;
using Jobfinding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobsService _service;
        public JobsController(IJobsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,ImageURL,Info")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                return View(jobs);
            }
            await _service.AddAsync(jobs);
            return RedirectToAction(nameof(Index));

        }
        //detail
        public async Task<IActionResult> Details(int id)
        {
            var jobsDetails = await _service.GetByIdAsync(id);

            if (jobsDetails == null) return View("NotFound");
            return View(jobsDetails);
        }
        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var jobsDetails = await _service.GetByIdAsync(id);

            if (jobsDetails == null) return View("NotFound");

            return View(jobsDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImageURL,Info")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                return View(jobs);
            }
            await _service.UpdateAsync(id, jobs);
            return RedirectToAction(nameof(Index));

        }
        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var jobsDetails = await _service.GetByIdAsync(id);

            if (jobsDetails == null) return View("NotFound");

            return View(jobsDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobsDetails = await _service.GetByIdAsync(id);

            if (jobsDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

    }
}
