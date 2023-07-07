using Jobfinding.Data.Base;
using Jobfinding.Data.ViewModels;
using Jobfinding.Models;

namespace Jobfinding.Data.Services
{
    public interface IFindjobsServices: IEntityBaseRepository<Findjobs>
    {
        Task<Findjobs> GetFindjobsByIdAsync(int id);

        Task<NewFindjobsDropDownVM> GetNewFindjobsDropDownValues();

        Task AddNewFIndjobsAsync(NewFindjobsVM data);
        Task UpdateFIndjobsAsync(NewFindjobsVM data);


    }
}
