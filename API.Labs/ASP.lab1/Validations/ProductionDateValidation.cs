using System.ComponentModel.DataAnnotations;

namespace ASP.lab1.Validations;

public class ProductionDateValidation : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        var date = value as DateTime?;

        if (date is null || date > DateTime.Now) 
            return false;

        return true;
    }
}
