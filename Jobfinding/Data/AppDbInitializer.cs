using Jobfinding.Data.Enums;
using Jobfinding.Data.Static;
using Jobfinding.Models;
using Microsoft.AspNetCore.Identity;

namespace Jobfinding.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //all tables
                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(new List<Jobs>()
                    {
                        new Jobs()
                        {
                          Name= "Google",
ImageURL= "https://cdn-icons-png.flaticon.com/512/270/270799.png?w=740&t=st=1686911203~exp=1686911803~hmac=704fbc8fb3aa78ee4d3c9137e136c7892c6a7e34ca5edbfd29327c9915e310b5",
Info= "Google is a multinational technology company ." },
                          new Jobs()
                        {
                            Name= "Facebook",
ImageURL= "https://1000logos.net/wp-content/uploads/2021/04/Facebook-logo-768x480.png",
Info="Facebook is a social networking platform ." },
                            new Jobs()
                        {
                            Name = "Amazon",
ImageURL = "https://1000logos.net/wp-content/uploads/2016/10/Amazon-Logo-640x400.png",
Info = "Amazon is an e-commerce company."
                        },
                            new Jobs()
                            {
Name = "Apple",
ImageURL = "https://1000logos.net/wp-content/uploads/2016/10/Apple-Logo-768x432.png",
Info = "Apple Inc. is a multinational technology company"
                            },
                           new Jobs()
                            {
Name = "Boshundhara",
ImageURL = "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/dpmftiehaeoufkkchpzr",
Info = "Boshundhara Group is one of the largest industrial conglomerates in Bangladesh"
                            }



                    }
                  );
                    context.SaveChanges();

                }
                if (!context.Skills.Any())
                {
                    context.Skills.AddRange(new List<Skill>()
                    {
                        new Skill()
                        {
                           Name = "Artificial Intelligence (AI)",
ImageURL = "https://www.simplilearn.com/ice9/free_resources_article_thumb/Advantages_and_Disadvantages_of_artificial_intelligence.jpg",
Info = "Proficient in developing AI systems and algorithms."
                        },
                          new Skill()
                        {
                            Name = "Cybersecurity",
                            ImageURL = "https://www.simplilearn.com/ice9/free_resources_article_thumb/Top_10_Cybersecurity_Trends_to_Watch_Out_For_in_2020.jpg",
                           Info = "Experienced in securing computer systems and networks" 
                        },
                            new Skill()
                        {
                            Name = "Data Science",
ImageURL = "https://www.simplilearn.com/ice9/free_resources_article_thumb/A-Day-in-the-Life-of-a-Data-Scientist_Banner.jpg",
Info = "Proficient in extracting insights from large and complex datasets."
                        },
                            new Skill()
                            {
Name = "Mobile App Development",
ImageURL = "https://www.simplilearn.com/ice9/free_resources_article_thumb/mobile_cloud_computing.jpg",
Info = "Proficient in developing mobile applications"
                            },
                            new Skill()
                            {
Name = "Cloud Computing",
ImageURL = "https://www.simplilearn.com/ice9/free_resources_article_thumb/What_is_Cloud_Scalability.jpg",
Info = "Experienced in designing, deploying cloud-based solutions."

                            }



                    }
                        );
                    context.SaveChanges();

                }
                if (!context.Companies.Any())
                {

                    context.Companies.AddRange(new List<Company>()
                    {
                        new Company()
                        {
                          Name= "Google",
ImageURL= "https://cdn.dribbble.com/users/904380/screenshots/2233565/attachments/415915/revised-google-logo.png?compress=1&resize=800x600&vertical=center",
Info= "Google is a multinational technology company ." },
                          new Company()
                        {
                            Name= "Facebook",
ImageURL= "https://1000logos.net/wp-content/uploads/2021/04/Facebook-logo-768x480.png",
Info="Facebook is a social networking platform ." },
                            new Company()
                        {
                            Name = "Amazon",
ImageURL = "https://1000logos.net/wp-content/uploads/2016/10/Amazon-Logo-640x400.png",
Info = "Amazon is an e-commerce company."
                        },
                            new Company()
                            {
Name = "Apple",
ImageURL = "https://1000logos.net/wp-content/uploads/2016/10/Apple-Logo-768x432.png",
Info = "Apple Inc. is a multinational technology company"
                            },
                           new Company()
                            {
Name = "Boshundhara",
ImageURL = "https://res.cloudinary.com/crunchbase-production/image/upload/c_lpad,f_auto,q_auto:eco,dpr_1/dpmftiehaeoufkkchpzr",
Info = "Boshundhara Group is one of the largest industrial conglomerates in Bangladesh"
                            }



                    }
                        );
                    context.SaveChanges();
                }
                if (!context.Findjobs.Any())
                {
                    context.Findjobs.AddRange(new List<Findjobs>()
                    {

                    new Findjobs()
                    {
                        Name = "Area Manager",
                        Description = "Advanced Chemical Industries",
                        Salary = 40000,
                        ImageURL = "https://seeklogo.com/images/A/aci-group-logo-BABDEC820D-seeklogo.com.png",
                        Startdate = DateTime.Now.AddDays(-10),
                        Enddate = DateTime.Now.AddDays(10),
                        JobsId = 5,
                        CompanyId = 11,
                        JobCategory =Enums.JobCategory.Marketing
                    },
                        new Findjobs()
                        {
                            Name = "Information Analyst",
                            Description = "Advanced Chemical Industries",
                            Salary =30000,
                            ImageURL = "https://seeklogo.com/images/A/aci-group-logo-BABDEC820D-seeklogo.com.png",
                            Startdate = DateTime.Now,
                            Enddate = DateTime.Now.AddDays(3),
                            JobsId = 4,
                            CompanyId = 12,
                             JobCategory =Enums.JobCategory.AI_Engineer
                        },
                      new Findjobs()
                        {
                            Name = "Marketing Officer",
                            Description = "Beximco Group of industries",
                            Salary =20000,
                            ImageURL = "https://seeklogo.com/images/B/beximco-logo-11739D37E0-seeklogo.com.png",
                            Startdate = DateTime.Now,
                            Enddate = DateTime.Now.AddDays(3),
                            JobsId = 5,
                            CompanyId = 13,
                             JobCategory =JobCategory.Marketing
                        },
                       new Findjobs()
                        {
                            Name = "Executive - Audit",
                            Description = "A Web Development Company",
                            Salary =20000,
                            ImageURL = "https://image.shutterstock.com/image-photo/image-260nw-2043826829.jpg",
                            Startdate = DateTime.Now,
                            Enddate = DateTime.Now.AddDays(1),
                            JobsId = 6,
                            CompanyId = 14,
                             JobCategory =JobCategory.Web_Developer
                        },
                        new Findjobs()
                        {
                            Name = "Senior Engineer (Die Casting)",
                            Description = "Walton Hi-Tech Industries PLC.",
                            Salary= 50000,
                            ImageURL = "https://seeklogo.com/images/W/walton-logo-6FFC938D01-seeklogo.com.png",
                            Startdate = DateTime.Now.AddDays(-10),
                            Enddate = DateTime.Now.AddDays(-2),
                            JobsId = 7,
                            CompanyId = 15,
                            JobCategory = JobCategory.UX_Designer


                    }
                    }
                        );
                    context.SaveChanges();
                }

                if (!context.skills_Findingjobs.Any()) {
                    context.skills_Findingjobs.AddRange(new List<skills_findingjobs>()
                    {

                    new skills_findingjobs()
                    {

                        FindjobsId = 15,
                        SkillId = 6

                        },
                     new skills_findingjobs()
                    {

                        FindjobsId = 16,
                        SkillId = 7

                        },
                      new skills_findingjobs()
                    {

                        FindjobsId = 17,
                        SkillId = 8

                        },
                       new skills_findingjobs()
                    {

                        FindjobsId = 18,
                        SkillId = 9

                        },
                        new skills_findingjobs()
                    {

                        FindjobsId = 19,
                        SkillId = 10

                        }
                 }
                    );
                    context.SaveChanges();

                }
                
                if (!context.question_anss.Any())
                {

                }
               



            }
        }

        public static async Task SeedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope =applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager =serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Employer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employer));
                if (!await roleManager.RoleExistsAsync(UserRoles.Seeker))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Seeker));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string empUserEmail = "hasib@gmail.com";

                var empUser = await userManager.FindByEmailAsync(empUserEmail);
                if (empUser == null)
                {
                    var newempUser = new ApplicationUser()
                    {
                        FullName = "Emp User",
                        UserName = "Emp-user",
                        Email = empUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newempUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newempUser, UserRoles.Employer);
                }


                string appUserEmail = "user@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",  
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Seeker);
                }
            }
        }       
            
    }
}
