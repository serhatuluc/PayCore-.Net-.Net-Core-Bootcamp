using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.CreateStaff
{
    public class CreateStaffCommandValidator:AbstractValidator<CreateStaffCommand>
    {
       
        public CreateStaffCommandValidator()
        {
            //Regex burada name,lastname,phoneNumber ve email validasyonu yapmak için kullanılmıştır.
            RuleFor(command => command.Model.name).MaximumLength(250).MinimumLength(3).Matches(@"^[a-zA-Z/]*$").NotNull();
            RuleFor(command => command.Model.lastname).MaximumLength(250).MinimumLength(3).Matches(@"^[a-zA-Z/]*$").NotNull();
            RuleFor(command => command.Model.email).Matches(@"^[a-zA-Z/(.@)]*$").EmailAddress();
            RuleFor(command => command.Model.dateOfBirth).Must(BetweenTwoDate).WithMessage("Tarih 11-11-1945 ve 10-10-2022 arasında olmalıdır.");
            RuleFor(command => command.Model.phoneNumber).Matches(@"^([+](\d{12}))$").WithMessage("Alan kodu girecek şekilde yazınız. Örnek: +905554443322");
            RuleFor(command => command.Model.salary).GreaterThan(2000).LessThan(9000);
            
        }

        //Bu custom validator tarihleri bu zaman aralığında check eder.
        //Fluentvalidation'da bulunan "must" komutuyla bu validator kullanıldı.
        bool BetweenTwoDate(DateTime _dateOfBirth)
        {
            if (_dateOfBirth > new DateTime(2002,10,10) && _dateOfBirth < new DateTime(1945, 11, 11))
            {
                return false;
            }
            return true;
        }
    }

   
}
