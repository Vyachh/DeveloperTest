using BMIWebApi.Enums;
using BMIWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace indexWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserindexController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Getindex([SwaggerParameter("Height",Required = true)] double height, [SwaggerParameter("Weight", Required = true)] double weight)
        {
            double index = Math.Round(weight / Math.Pow(height / 100, 2),2);
            string description = BMIResult.GetBMIDescriptionByIndex(index);
            string finalStr = $"Ваш индекс массы тела: {index} кг/м2. {description}.";

            var result = new BMIResult()
            {
                Index = index,
                Description = description,
                FinalString = finalStr
            };

            return Ok(result);
        } 
    }
}
