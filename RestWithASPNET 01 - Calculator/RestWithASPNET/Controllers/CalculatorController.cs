using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {


        // GET api/5/5
        [HttpGet("{firstnumber}/{secondNumber}")]
        public IActionResult Sum(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal.TryParse(number, out decimal numberConverted);
            return numberConverted;
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out _);

            return isNumber;
        }
    }
}
