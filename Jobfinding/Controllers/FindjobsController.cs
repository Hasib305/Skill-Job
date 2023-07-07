using Jobfinding.Data;
using Jobfinding.Data.Services;
using Jobfinding.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Controllers
{
    public class FindjobsController : Controller
    {
        private readonly IFindjobsServices _service;
        public FindjobsController(IFindjobsServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n =>n.Jobs);
            return View(data);
        }
        //filter
        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(n => n.Jobs);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = data.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString) || n.JobCategory.ToString().Contains(searchString)).ToList();

                return View("Index",filteredResult);
            }
            return View("Index",data);
        }
        //create
        public async  Task<IActionResult> Create()
        {
            var data = await _service.GetNewFindjobsDropDownValues();
            ViewBag.Jobs = new SelectList(data.Jobs, "Id", "Name");
            ViewBag.Companys = new SelectList(data.Companys, "Id", "Name");
            ViewBag.Skills = new SelectList(data.Skills, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create( NewFindjobsVM jobs)
        {
            if (!ModelState.IsValid)
            {
                var data = await _service.GetNewFindjobsDropDownValues();
                ViewBag.Jobs = new SelectList(data.Jobs, "Id", "Name");
                ViewBag.Companys = new SelectList(data.Companys, "Id", "Name");
                ViewBag.Skills = new SelectList(data.Skills, "Id", "Name");
                return View();
                return View(jobs);
            } 
            await _service.AddNewFIndjobsAsync(jobs);
            return RedirectToAction(nameof(Index));

        }

        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var findjobsDetails = await _service.GetFindjobsByIdAsync(id);
            if (findjobsDetails == null) return View("NotFound");

            var response = new NewFindjobsVM()
            {
                Id = findjobsDetails.Id,
                Name = findjobsDetails.Name,
                Description = findjobsDetails.Description,
                Salary = findjobsDetails.Salary,
                Startdate=findjobsDetails.Startdate,
                Enddate=findjobsDetails.Enddate,
                ImageURL = findjobsDetails.ImageURL,
                JobCategory = findjobsDetails.JobCategory,
                JobsId = findjobsDetails.JobsId,
                CompanyId = findjobsDetails.CompanyId,
                SkillIds = findjobsDetails.skills_Findingjobs.Select(n => n.SkillId).ToList(),

            };
            var data = await _service.GetNewFindjobsDropDownValues();
            ViewBag.Jobs = new SelectList(data.Jobs, "Id", "Name");
            ViewBag.Companys = new SelectList(data.Companys, "Id", "Name");
            ViewBag.Skills = new SelectList(data.Skills, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewFindjobsVM jobs)
        {
            if (id != jobs.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var data = await _service.GetNewFindjobsDropDownValues();
                ViewBag.Jobs = new SelectList(data.Jobs, "Id", "Name");
                ViewBag.Companys = new SelectList(data.Companys, "Id", "Name");
                ViewBag.Skills = new SelectList(data.Skills, "Id", "Name");
                return View();
                return View(jobs);
            }
            await _service.UpdateFIndjobsAsync(jobs);
            return RedirectToAction(nameof(Index));

        }

        //detail
        public async Task<IActionResult> Details(int id)
        {
            var jobsDetails = await _service.GetFindjobsByIdAsync(id);

            return View(jobsDetails);
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
