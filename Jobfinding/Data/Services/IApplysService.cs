using Jobfinding.Models;

namespace Jobfinding.Data.Services
{
    public interface IApplysService
    {

        Task StoreApplyAsync(List<ApplyCartItem> items, string userId, string userEmailAddress);
        Task<List<Apply>> GetApplysByUserIdAndRoleAsync(string userId,string userRole);
    }
}
 