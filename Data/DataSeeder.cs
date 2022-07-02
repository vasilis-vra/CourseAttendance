using CourseAttendanceAPI.Enums;
using CourseAttendanceAPI.Models;

namespace CourseAttendanceAPI.Data
{
    public class DataSeeder
    {
        public static void PopulateMockData(IApplicationBuilder applicationBuilder)
        {
            using(var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        Name = "Mathematics",
                        Description = "Introductory class to advanced Mathematics.",
                        Semester = Semester.Fall.ToString()
                    },
                    new Course
                    {
                        Name = "Physics",
                        Description = "Introductory class to advanced Physics.",
                        Semester = Semester.Fall.ToString()
                    },
                    new Course
                    {
                        Name = "Computer Science",
                        Description = "Introductory class to Computer Science.",
                        Semester = Semester.Fall.ToString()
                    },
                    new Course
                    {
                        Name = "Robotics",
                        Description = "Introductory class to robotics.",
                        Semester = Semester.Spring.ToString()
                    },
                    new Course
                    {
                        Name = "Intro to algorithms",
                        Description = "Introductory class to algorithms and data structures.",
                        Semester = Semester.Spring.ToString()
                    },
                    new Course
                    {
                        Name = "Machine Learning",
                        Description = "Class about A.I. and machine learning practices.",
                        Semester = Semester.Spring.ToString()
                    },
                    new Course
                    {
                        Name = "Biology",
                        Description = "Introductory class to biology.",
                        Semester = Semester.Fall.ToString()
                    },
                    new Course
                    {
                        Name = "Intro to Psychology",
                        Description = "Introductory class to psychology.",
                        Semester = Semester.Spring.ToString()
                    },
                    new Course
                    {
                        Name = "Accounting",
                        Description = "Class about the accounting practices that offers both theoretical and practical knowledge.",
                        Semester = Semester.Spring.ToString()
                    },
                    new Course
                    {
                        Name = "Political Science",
                        Description = "Introductory class to political science.",
                        Semester = Semester.Fall.ToString()
                    },
                    new Course
                    {
                        Name = "Art",
                        Description = "Art class.",
                        Semester = Semester.Spring.ToString()
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Suzanna",
                        LastName = "Kleinschmidt",
                        Email = "skleinschmidt0@twitter.com"
                    },
                    new Student
                    {
                        FirstName = "Lorena",
                        LastName = "Olivello",
                        Email = "lolivello1@nih.gov"
                    },
                    new Student
                    {
                        FirstName = "Pris",
                        LastName = "Staite",
                        Email = "pstaite2@jugem.jp"
                    },
                    new Student
                    {
                        FirstName = "Rip",
                        LastName = "Farrans",
                        Email = "rfarrans3@prweb.com"
                    },
                    new Student
                    {
                        FirstName = "Jamie",
                        LastName = "Camellini",
                        Email = "jcamellini4@gov.uk"
                    },
                    new Student
                    {
                        FirstName = "Yank",
                        LastName = "Rowles",
                        Email = "yrowles5@xinhuanet.com"
                    }, new Student
                    {
                        FirstName = "Jemmie",
                        LastName = "Hatch",
                        Email = "jhatch6@youtu.be"
                    }, new Student
                    {
                        FirstName = "Sergeant",
                        LastName = "Kirman",
                        Email = "skirman7@techcrunch.com"
                    }, new Student
                    {
                        FirstName = "Amara",
                        LastName = "Attrey",
                        Email = "aattrey8@alibaba.com"
                    }, new Student
                    {
                        FirstName = "Brian",
                        LastName = "Paolillo",
                        Email = "bpaolillo9@wordpress.com"
                    }, new Student
                    {
                        FirstName = "Celie",
                        LastName = "Thomesson",
                        Email = "cthomessona@indiatimes.com"
                    }, new Student
                    {
                        FirstName = "Audy",
                        LastName = "Haggish",
                        Email = "ahaggishb@cafepress.com"
                    }, new Student
                    {
                        FirstName = "Faith",
                        LastName = "Caughtry",
                        Email = "fcaughtryc@ameblo.jp"
                    }, new Student
                    {
                        FirstName = "Barbra",
                        LastName = "Fossey",
                        Email = "bfosseyd@va.gov"
                    }, new Student
                    {
                        FirstName = "Lana",
                        LastName = "McAlinion",
                        Email = "lmcalinione@weather.com"
                    }, new Student
                    {
                        FirstName = "Keslie",
                        LastName = "Rubega",
                        Email = "krubegaf@howstuffworks.com"
                    }, new Student
                    {
                        FirstName = "Leeland",
                        LastName = "Loch",
                        Email = "llochg@earthlink.net"
                    }, new Student
                    {
                        FirstName = "Ilario",
                        LastName = "Cantos",
                        Email = "icantosh@discovery.com"
                    }, new Student
                    {
                        FirstName = "Beatriz",
                        LastName = "Durrett",
                        Email = "bdurretti@jalbum.net"
                    }, new Student
                    {
                        FirstName = "Morna",
                        LastName = "Spurdle",
                        Email = "mspurdlej@shutterfly.com"
                    }
                    );
                context.SaveChanges();
            }
            return;
        }
    }
}
