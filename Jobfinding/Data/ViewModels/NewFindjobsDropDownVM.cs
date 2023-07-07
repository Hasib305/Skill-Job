using Jobfinding.Models;

namespace Jobfinding.Data.ViewModels
{
    public class NewFindjobsDropDownVM
    {
        public NewFindjobsDropDownVM()
        {
            Companys = new List<Company>();
            Jobs = new List<Jobs>();
            Skills=new List<Skill>();
        }
        public List<Company> Companys { get; set; }
        public List<Jobs>Jobs  { get; set; }
        public List<Skill> Skills { get; set; }
    } 
}
