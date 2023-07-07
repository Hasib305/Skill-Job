using Jobfinding.Data.Base;
using Jobfinding.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobfinding.Models
{
    public class Findjobs:IEntityBase
    { 

        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double Salary { get; set; }
        public string ImageURL { get; set; }

        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public JobCategory JobCategory { get; set;}
        //rel
        public List<skills_findingjobs> skills_Findingjobs { get; set; }

        public List<question_ans> question_ans{ get; set; }

        //job

        public int JobsId { get; set; }
        [ForeignKey("JobsId")] 
        public Jobs Jobs { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }



    }
}
