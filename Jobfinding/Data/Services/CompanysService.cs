using Jobfinding.Data.Base;
using Jobfinding.Models;

namespace Jobfinding.Data.Services
{
    public class CompanysService: EntityBaseRepository<Company>,ICompanysService
    {
        public CompanysService(AppDbContext context) : base(context)
        {
        }
    }
}
