using System.ComponentModel.DataAnnotations;

namespace Jobfinding.Models
{
    public class Assesment
    {
        [Key]
        public int Id { get; set; }
        public string logo { get; set; }
        public string name { get; set; }
        public string Info { get; set; }
    }
}
