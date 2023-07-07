using Jobfinding.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Jobfinding.Models
{
    public class Company:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Companylogo")]
        [Required(ErrorMessage ="Image is Required")]
        public string ImageURL { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Name must be between 3 and  50 chars")]
        public string Name { get; set; }
        [Display(Name = "Detail")]
        [Required(ErrorMessage = "Information is required")]
        public string Info { get; set; }
        public List<Findjobs>findjobs { get; set; }
    }
}

