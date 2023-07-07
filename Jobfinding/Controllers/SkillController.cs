using Jobfinding.Data;
using Jobfinding.Data.Services;
using Jobfinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jobfinding.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _service;
        public SkillController(ISkillService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
             var data =await _service.GetAllAsync(); 
            return View(data);
        }
        //create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> Create([Bind("Name,ImageURL,Info")]Skill skill)
        {
            if(ModelState.IsValid)
            {
                return View(skill);
            }
            await _service.AddAsync(skill);
            return RedirectToAction(nameof(Index));

        }
        //detail
        public async Task<IActionResult> Details(int id)
        {
            var skillDetails =await _service.GetByIdAsync(id);

            if (skillDetails == null) return View("NotFound");
            return View(skillDetails);
        }
        //Edit
        public async Task<IActionResult> Edit(int id)
        {
            var skillDetails = await _service.GetByIdAsync(id);

            if (skillDetails == null) return View("NotFound");

            return View(skillDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Name,ImageURL,Info")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                return View(skill);
            }
            await _service.UpdateAsync(id,skill);
            return RedirectToAction(nameof(Index));

        }
        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var skillDetails = await _service.GetByIdAsync(id);

            if (skillDetails == null) return View("NotFound");

            return View(skillDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skillDetails = await _service.GetByIdAsync(id);

            if (skillDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
           
            return RedirectToAction(nameof(Index));

        }

    }
}
 