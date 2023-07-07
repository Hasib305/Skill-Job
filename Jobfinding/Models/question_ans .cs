using System.ComponentModel.DataAnnotations.Schema;

namespace Jobfinding.Models
{
    public class question_ans
    {

        public int Id { get; set; }
        public string Question { get; set; }
        public string Opt_1 { get; set; }
        public string Opt_2 { get; set; }
        public string Opt_3 { get; set; }
        public string Opt_4 { get; set; }
        public int Ans { get; set; }

        public int FindjobsId { get; set; }
        [ForeignKey("FindjobsId")]
        public Findjobs Findjobs { get; set; }
    }
}
