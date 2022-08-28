using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompoundInterest.Models.Validators
{
    public class ParameterValidators :AbstractValidator<Parameters>
    {
        public ParameterValidators()
        {
            //Para miktarı boş veya 0 dan az girilemez
            RuleFor(x => x.capital).GreaterThan(0).NotEmpty();
          

            //Faiz oranı boş veya 0 dan az girilemez
            RuleFor(x => x.interest).GreaterThan(0).NotEmpty();
           
            
            //Vade boş veya 0 dan az girilemez
            RuleFor(x => x.term).GreaterThan(0).NotEmpty();
         

        }
    }
}
