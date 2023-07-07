using Jobfinding.Data.Base;
using Jobfinding.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data.Services
{
    public class SkillService :EntityBaseRepository<Skill>, ISkillService
    {
        private readonly AppDbContext _context;
        public SkillService(AppDbContext context): base(context) { }
        
       
    }
}
