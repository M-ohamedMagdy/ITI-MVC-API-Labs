using lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult AllCars()
        {
            var cars = Car.GetCars();
            return View(cars);
        }
        public IActionResult Details(string model, Status source) 
        {
            var car = Car.GetCars().First(a=>a.Model == model);
            Source carDetails = new() { car = car, source = source }; 
            return View(carDetails);
        }
    }
}
