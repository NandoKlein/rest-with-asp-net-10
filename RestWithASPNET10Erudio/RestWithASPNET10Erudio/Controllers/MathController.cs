using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        [HttpGet("calc/{operation}/{firstNumber}/{secondNumber}")]        
        public IActionResult Get(string operation, string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                switch (operation)
                {
                    case "Soma":
                        return Somar(firstNumber, secondNumber);

                    case "Subtrair":
                        return Subtrair(firstNumber, secondNumber);

                    case "Dividir":
                        return Dividir(firstNumber, secondNumber);

                    case "Multiplicar":
                        return Multiplicar(firstNumber, secondNumber);

                    case "Media":
                        return Media(firstNumber, secondNumber);
                }

            }
            return BadRequest("Invalid imput");
        }
        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Get(string firstNumber)
        {
            if (IsNumeric(firstNumber))
                return Raiz(firstNumber);

            return BadRequest("Invalid imput");
        }

        private IActionResult Subtrair(string firstNumber, string secondNumber)
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub);
        }

        private IActionResult Somar(string firstNumber, string secondNumber)
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum);
        }

        private IActionResult Dividir(string firstNumber, string secondNumber)
        {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div);
        }

        private IActionResult Multiplicar(string firstNumber, string secondNumber)
        {
            var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mult);
        }

        private IActionResult Media(string firstNumber, string secondNumber)
        {
            var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return Ok(media);
        }

        private IActionResult Raiz(string firstNumber)
        {           
            var raiz = Math.Sqrt((Double)ConvertToDecimal(firstNumber));
            return Ok(raiz);
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal decimalValue))
                return decimalValue;
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            return decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimal decimalValue);

        }
    }
}
