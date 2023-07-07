using System.ComponentModel.DataAnnotations;

namespace Jobfinding.Models
{
    public class ApplyCartItem
    {
        [Key]
        public int Id { get; set; }

        public Findjobs Findjobs { get; set; }

        public int Amount { get; set; }

        public string ApplyCartId { get; set; }

    }
}
