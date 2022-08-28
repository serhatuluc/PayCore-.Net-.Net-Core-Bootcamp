using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using CompoundInterest.Models.Validators;
using FluentValidation.Results;

namespace CompoundInterest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        [HttpGet]
        public IActionResult get([FromQuery] Parameters parameters)
        {
            //Validator oluşturuldu
            ParameterValidators pv = new ParameterValidators();
            ValidationResult results = pv.Validate(parameters);

            //Geçersiz parametreler alındıysa error mesajı döndürecek validator
            if (!results.IsValid)
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }


            //Faiz işleyip toplam miktarı hesaplar
            double balance = parameters.capital * Math.Pow((1 + parameters.interest / 100), parameters.term);

            //Toplam parayı ve faiz miktarını döndürür
            return Ok(new CompoundInterest
            {
                InterestAmount = Math.Round(balance - parameters.capital, 2),
                TotalBalance = Math.Round(balance, 2)
            });
        }  
    }
}
