using ASP.lab1.Filters;
using ASP.lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASP.lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<CarsController>  logger;
        public static int RequestCounter = 0;
        public CarsController(ILogger<CarsController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public ActionResult<List<Car>> GetAll() 
        {
            //return Ok(Car.GetAllCars());
            return Car.AllCars;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Car> GetOne(int id)
        {
            Car? car = Car.AllCars.FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound(ResponseMessage.NotFound);
            }

            return car;
        }
        [HttpPost]
        [Route("v1")]
        public IActionResult Add(Car carToAdd) 
        {
            carToAdd.Type = "GAS";
            Car.AllCars.Add(carToAdd);
            return CreatedAtAction(
                actionName: nameof(GetAll), 
                value:ResponseMessage.Added);
        }
        [HttpPost]
        [Route("v2")]
        [ServiceFilter(typeof(ValidateCarTypeAttribute))]
        public IActionResult Addv2(Car carToAdd) 
        {
            Car.AllCars.Add(carToAdd);
            return CreatedAtAction(
                actionName: nameof(GetAll), 
                value:ResponseMessage.Added);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Edit(Car car, int id) 
        {
            if(car.Id != id)
            {
                return BadRequest(ResponseMessage.Unauthorizd);
            }

            Car? carToEdit = Car.AllCars.FirstOrDefault(c => car.Id == id);

            if(carToEdit is null)
            {
                return NotFound(ResponseMessage.NotFound);
            }

            carToEdit.Brand = car.Brand;
            carToEdit.Model = car.Model;
            carToEdit.Price = car.Price;
            carToEdit.ProductionDate = car.ProductionDate;

            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id) 
        { 
            Car? carToDelete = Car.AllCars.FirstOrDefault(c => c.Id == id);

            if(carToDelete is null) 
            {
                return NotFound(ResponseMessage.NotFound);
            }

            Car.AllCars.Remove(carToDelete);

            return CreatedAtAction(actionName: nameof(GetAll), value: ResponseMessage.Deleted);
        }

        [HttpGet]
        [Route("RequestCount")]
        public string Count() => $"Number of requests sent : {RequestCounter}";
    }
}
