using Jobfinding.Data.Static;
using Jobfinding.Models;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data.Services
{
    public class ApplysService : IApplysService
    {
        private readonly AppDbContext _context;
        public ApplysService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apply>> GetApplysByUserIdAndRoleAsync(string userId,string userRole)
        {
            var applys = await _context.Apply.Include(n=>n.applyitems).ThenInclude(n=>n.Findjobs).Include(n=>n.User).ToListAsync();
               
            
            if(userRole != "Employer")
            {
                applys=applys.Where(n=>n.UserId == userId).ToList();
            }
            return applys;
        }

        public async Task StoreApplyAsync(List<ApplyCartItem> items, string userId, string userEmailAddress)
        {
            var apply = new Apply()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Apply.AddAsync(apply);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var applyItem = new Applyitem()
                {
                    Amount = item.Amount,
                    FindjobId = item.Findjobs.Id,
                    ApplyId = apply.Id,
                    Fee = (item.Findjobs.Salary)*10/100
                };
                await _context.Applyitems.AddAsync(applyItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}