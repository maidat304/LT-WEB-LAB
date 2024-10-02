using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab.Controllers
{
    public static class Database
    {
        public static List<Student> listStudents = new List<Student>()
        {
            new Student()
            {
                Id = 101,
                Name = "Hai Nam",
                Branch = Branchs.IT,
                Gender = Gender.Male,
                IsRegular = true,
                Address = "A1-2018",
                Email = "nam@gmail.com",
                Point = 5.5,
                Avatar = "/avatars/default.png"
            },
            new Student()
            {
                Id = 102,
                Name = "Minh Tu",
                Branch = Branchs.BE,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A1-2019",
                Email = "tu@gmail.com",
                Point = 7.5,
                Avatar = "/avatars/default.png"
            },
            new Student()
            {
                Id = 103,
                Name = "Hoang Phong",
                Branch = Branchs.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "A1-2020",
                Email = "phong@gmail.com",
                Point = 4,
                Avatar = "/avatars/default.png"
            },
            new Student()
            {
                Id = 104,
                Name = "Xuan Mai",
                Branch = Branchs.EE,
                Gender = Gender.Female,
                IsRegular = false,
                Address = "A1-2021",
                Email = "mai@gmail.com",
                Point = 8.5,
                Avatar = "/avatars/default.png"
            },
            new Student()
            {
                Id = 105,
                Name = "Hai Yen",
                Branch = Branchs.IT,
                Gender = Gender.Female,
                IsRegular = true,
                Address = "A1-2022",
                Email = "yenh@gmail.com",
                Point = 6.5,
                Avatar = "/avatars/default.png"
            }
        };
    }

    public class StudentController : Controller
    {

        public IActionResult Index()
        {
            return View(Database.listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.AllGender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranchs = new List<SelectListItem>
            {
                new SelectListItem { Text = "IT", Value = "0" },
                new SelectListItem { Text = "BE", Value = "1" },
                new SelectListItem { Text = "CE", Value = "2" },
                new SelectListItem { Text = "EE", Value = "3" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student, IFormFile avatarFile)
        {
            
            if (avatarFile != null && avatarFile.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/avatars", avatarFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    avatarFile.CopyTo(stream);
                }
                student.Avatar = "/avatars/" + avatarFile.FileName;
            }
            else
            {
                student.Avatar = "/avatars/default.png";
            }

            ModelState.Remove("avatarFile");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is not valid");
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage); 
                }

                
                ViewBag.AllGender = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
                ViewBag.AllBranchs = new List<SelectListItem>
        {
            new SelectListItem { Text = "IT", Value = "0" },
            new SelectListItem { Text = "BE", Value = "1" },
            new SelectListItem { Text = "CE", Value = "2" },
            new SelectListItem { Text = "EE", Value = "3" }
        };

                return View(student);
            }

            student.Id = Database.listStudents.Count + 1;
            Database.listStudents.Add(student);
            return RedirectToAction("Index");
        }

    }
}
