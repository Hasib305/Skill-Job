using Jobfinding.Data.Base;
using Jobfinding.Data.ViewModels;
using Jobfinding.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data.Services
{
    public class FindjobsServices: EntityBaseRepository<Findjobs>,IFindjobsServices
    {
        private readonly AppDbContext _context;
        public FindjobsServices(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewFIndjobsAsync(NewFindjobsVM data)
        {
            var newFindjobs = new Findjobs()
            {
                Name = data.Name,
                Description = data.Description,
                Salary = data.Salary,
                ImageURL = data.ImageURL,
                JobsId = data.JobsId,
                Startdate = data.Startdate,
                Enddate = data.Enddate,
                JobCategory = data.JobCategory,
                CompanyId = data.CompanyId
            };
            await _context.Findjobs.AddAsync(newFindjobs);
            await _context.SaveChangesAsync();

            foreach (var skillid in data.SkillIds)
            {
                var newSkillfindjobs = new skills_findingjobs()
                {
                    FindjobsId = newFindjobs.Id,
                    SkillId = skillid

                };
                await _context.skills_Findingjobs.AddAsync(newSkillfindjobs); 
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Findjobs> GetFindjobsByIdAsync(int id)
        {
            var findjobDetails = await _context.Findjobs
                .Include(c => c.Jobs)
                .Include(p => p.Company)
                .Include(am => am.skills_Findingjobs).ThenInclude(a => a.Skill)
                 .Include(p => p.question_ans)
                .FirstOrDefaultAsync(n => n.Id == id);

            return findjobDetails;
        }

        public async Task<NewFindjobsDropDownVM> GetNewFindjobsDropDownValues()
        {
            var response = new NewFindjobsDropDownVM()
            {
                Skills = await _context.Skills.OrderBy(n => n.Name).ToListAsync(),
                Jobs = await _context.Jobs.OrderBy(n => n.Name).ToListAsync(),
                Companys = await _context.Companies.OrderBy(n => n.Name).ToListAsync(),
            };
            return response;
        }

        public async Task UpdateFIndjobsAsync(NewFindjobsVM data)
        {
           
            var dbFindjobs = await _context.Findjobs.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbFindjobs != null)
            {

                dbFindjobs.Name = data.Name;
                dbFindjobs.Description = data.Description;
                dbFindjobs.Salary = data.Salary;
                dbFindjobs.ImageURL = data.ImageURL;
                dbFindjobs.JobsId = data.JobsId;
                dbFindjobs.Startdate = data.Startdate;
                dbFindjobs.Enddate = data.Enddate;
                dbFindjobs.JobCategory = data.JobCategory;
                dbFindjobs.CompanyId = data.CompanyId;
                
               
                await _context.SaveChangesAsync();

            }
            var existingFindjobsDV= _context.skills_Findingjobs.Where(n=>n.FindjobsId==data.Id).ToList();
            _context.skills_Findingjobs.RemoveRange(existingFindjobsDV);

            foreach (var skillid in data.SkillIds)
            {
                var newSkillfindjobs = new skills_findingjobs()
                {
                    FindjobsId = data.Id,
                    SkillId = skillid

                };
                await _context.skills_Findingjobs.AddAsync(newSkillfindjobs);
            }
            await _context.SaveChangesAsync();
        }
    }
}