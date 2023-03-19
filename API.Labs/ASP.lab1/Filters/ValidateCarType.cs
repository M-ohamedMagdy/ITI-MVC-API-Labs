using ASP.lab1.Controllers;
using ASP.lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace ASP.lab1.Filters
{
    public class ValidateCarTypeAttribute : ActionFilterAttribute
    {
        private readonly ILogger<ValidateCarTypeAttribute> logger;
        public ValidateCarTypeAttribute(ILogger<ValidateCarTypeAttribute> _logger)
        {
            logger = _logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Custom action filter");
            
            var allowedTypesRegex = new Regex("^[GAS|ELECTRIC|DESIEL|HYBRID]$", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

            Car? car = context.ActionArguments["carToAdd"] as Car;

            if(car is null || !allowedTypesRegex.IsMatch(car.Type))
            { 
                context.Result = new BadRequestObjectResult(ResponseMessage.WrongType);
            }
        }
    }
}
