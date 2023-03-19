using ASP.lab1.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.lab1.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Price { get; set; }
    [ProductionDateValidation]
    public DateTime ProductionDate { get; set; }
    public string Type { get; set; } = string.Empty;
    public static List<Car> AllCars { get; set; } = new()
    {
        new Car { Id=1, Brand = "BMW", Model = "i320", Price = 1000, ProductionDate=new DateTime(2023,1,1), Type="GAS" },
        new Car { Id=2, Brand = "BMW", Model = "i540", Price = 2000, ProductionDate=new DateTime(2023,2,2), Type="GAS" },
        new Car { Id=3, Brand = "BMW", Model = "X4", Price = 3000, ProductionDate=new DateTime(2023,3,3), Type="GAS" },
        new Car { Id=4, Brand = "BMW", Model = "X6", Price = 4000, ProductionDate=new DateTime(2023,2,1), Type="GAS" },
    };
    public Car() { }
}
