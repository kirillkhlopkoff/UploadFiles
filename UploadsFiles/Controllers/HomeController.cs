using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using UploadsFiles.Models;
using UploadsFiles.ViewModels;

namespace UploadsFiles.Controllers
{
    public class HomeController : Controller
    {
        AppContext _context;

        public HomeController(AppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel pvm)
        {
            Person person = new Person { Name = pvm.Name };
            if (pvm.Avatar != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Avatar.Length);
                }
                // установка массива байтов
                person.Avatar = imageData;
            }
            _context.People.Add(person);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
