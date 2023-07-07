using Jobfinding.Data.Base;
using Jobfinding.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data.Services
{
    public class JobsService :EntityBaseRepository<Jobs>, IJobsService
    {
        private readonly AppDbContext _context;
        public JobsService(AppDbContext context): base(context) { }
        
       
    }
}
