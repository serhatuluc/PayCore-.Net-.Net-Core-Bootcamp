using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.GetStaffById
{
    public class GetStaffByIdQueryValidator: AbstractValidator<GetStaffByIdQuery>
    {
        public GetStaffByIdQueryValidator()
        {
            //Id 0'dan büyük olmalıdır
            RuleFor(command => command.StaffId).GreaterThan(0);
        }
    }
}
