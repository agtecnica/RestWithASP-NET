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
        // GET api/sum/5/5
        [HttpGet("sum/{firstnumber}/{secondNumber}")]
        public IActionResult Sum(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/subtraction/5/5
        [HttpGet("subtraction/{firstnumber}/{secondNumber}")]
        public IActionResult Sub(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstnumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/mult/5/5
        [HttpGet("mult/{firstnumber}/{secondNumber}")]
        public IActionResult Mult(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                var mult = ConvertToDecimal(firstnumber) * ConvertToDecimal(secondNumber);
                return Ok(mult.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/avg/5/5
        [HttpGet("avg/{firstnumber}/{secondNumber}")]
        public IActionResult Avg(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                var avg = (ConvertToDecimal(firstnumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(avg.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/sqrt/9
        [HttpGet("sqrt/{firstnumber}")]
        public IActionResult sqrt(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber))
            {
                var sqrt = Math.Sqrt(ConvertToDouble(firstnumber));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid Input");
        }

        // GET api/Div/3/2
        [HttpGet("div/{firstnumber}/{secondNumber}")]
        public IActionResult Division(string firstnumber, string secondNumber)
        {
            if (IsNumeric(firstnumber) && IsNumeric(secondNumber))
            {
                if (ConvertToDecimal(secondNumber) == 0)
                    return BadRequest("Invalid second Number");

                var dividend = ConvertToDecimal(firstnumber) / ConvertToDecimal(secondNumber);
                return Ok(dividend.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal.TryParse(number, out decimal numberConverted);
            return numberConverted;
        }

        private double ConvertToDouble(string number)
        {
            double.TryParse(number, out double numberConverted);
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
