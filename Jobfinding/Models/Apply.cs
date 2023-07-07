using System.ComponentModel.DataAnnotations.Schema;

namespace Jobfinding.Models
{
    public class Apply
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
       
        public List<Applyitem> applyitems { get; set; }
    }
}
