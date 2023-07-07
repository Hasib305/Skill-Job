using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobfinding.Models
{
    public class Applyitem
    {
        [Key]
        public int Id { get; set; }
        public  int Amount { get; set; }

        public double Fee { get; set; }

        public int FindjobId { get; set; }
        [ForeignKey("FindjobId")]
        public   Findjobs Findjobs { get; set; }

        public int ApplyId { get; set; }
        [ForeignKey("ApplyId")]
        public Apply Apply { get; set; }

    }
}
