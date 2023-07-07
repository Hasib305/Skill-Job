 using Jobfinding.Data.Base;
using Jobfinding.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobfinding.Models
{
    public class NewFindjobsVM  
    {
     
        public int Id { get; set; }
        [Display(Name="Job name")]
        [Required(ErrorMessage ="name is required")]
        public String Name { get; set; }
        [Display(Name = "job describtion")]
        [Required(ErrorMessage = "describtion is required")] 
        public String Description { get; set; }

        [Display(Name = "Salary in $")]
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }
        [Display(Name = "Job Image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }
        [Display(Name = "Start Data")]
        [Required(ErrorMessage = "STartdate is required")]
        public DateTime Startdate { get; set; }
        [Display(Name = "End Data")]
        [Required(ErrorMessage = "Enddate is required")]
        public DateTime Enddate { get; set; }
        [Display(Name = "Job Category")]
        [Required(ErrorMessage = "Job Category  is required")]
        public JobCategory JobCategory { get; set;}
        //rel
        [Display(Name = "Select SKill(s)")]
        [Required(ErrorMessage = "Job Skill(s) is required")]
        public List<int> SkillIds { get; set; }



        //job
        [Display(Name = "Select a job")]
        [Required(ErrorMessage = "job is required")]
        public int JobsId { get; set; }
        [Display(Name = "Select Company")]
        [Required(ErrorMessage = "Company is required")]
        public int CompanyId { get; set; }
       



    }
}
