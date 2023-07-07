using Jobfinding.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Jobfinding.Models
{
    public class Skill: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Image is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Skills")]
        [Required(ErrorMessage = "Skill name is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Skill name must be between 3 and 40 characters")]
        public string Name { get; set; }

        [Display(Name = "Details")]
        [Required(ErrorMessage = "Details is required")]
        public string Info { get; set; }

        public List<skills_findingjobs> skills_Findingjobs { get; set; }
    }
}
