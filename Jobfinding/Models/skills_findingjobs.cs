namespace Jobfinding.Models
{
    public class skills_findingjobs
    {
        public int FindjobsId  { get; set; }

        public Findjobs Findjobs { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

    }
}
