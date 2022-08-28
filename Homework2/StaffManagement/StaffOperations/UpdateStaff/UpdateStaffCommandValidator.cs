using FluentValidation;
using StaffManagement.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.UpdateStaff
{
    public class UpdateStaffCommandValidator : AbstractValidator<UpdateStaffCommand>
    {
        public UpdateStaffCommandValidator()
        {
            //Regex burada name,lastname,phoneNumber ve email validasyonu yapmak için kullanılmıştır. 
            RuleFor(command => command.Model.name).MaximumLength(250).MinimumLength(3).Matches(@"^[a-zA-Z/]*$");
            RuleFor(command => command.Model.lastname).MaximumLength(250).MinimumLength(3).Matches(@"^[a-zA-Z/]*$");

            //Email için aynı zamanda EmailAdress doğrulaması yapılıyor.
            RuleFor(command => command.Model.email).Matches(@"^[a-zA-Z/(.@)]*$").EmailAddress();

            //BetweenTwoDate bir Custom Validator olarak hazırlanmıştır. Sayfanın sonunda görülebilir.
            //Bir extension olan IsNow burada kullanılmıştır. Eğer bu data boş bırakılırsa data güncellenmeden bırakılacaktır.
            //When koşulu false döndürdüğünde validasyon error döndürmeyecektir.
            RuleFor(command => command.Model.dateOfBirth).Must(BetweenTwoDate).WithMessage("Tarih 11-11-1945 ve 10-10-2022 arasında olmalıdır.").When(command => command.Model.dateOfBirth.IsNotNow());

            RuleFor(command => command.Model.phoneNumber).Matches(@"^([+](\d{12}))$").WithMessage("Alan kodu girecek şekilde yazınız. Örnek: +905554443322");

            //IsZero extension olarak kullanılmıştır. Extension dosyasında bulunmaktadır.
            RuleFor(command => command.Model.salary).GreaterThan(2000).LessThan(9000).When(command => command.Model.salary.IsNotZero());

        }
        
        //Bu custom validator tarihleri bu zaman aralığında check eder.
        bool BetweenTwoDate(DateTime _dateOfBirth)
        {
            if (_dateOfBirth > new DateTime(2002, 10, 10) && _dateOfBirth < new DateTime(1945, 11, 11))
            {
                return false;
            }
            return true;
        }
    }

}

