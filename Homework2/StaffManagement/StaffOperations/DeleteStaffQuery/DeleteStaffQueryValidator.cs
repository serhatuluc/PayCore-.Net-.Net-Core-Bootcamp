using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.DeleteStaffQuery
{
    public class DeleteStaffQueryValidator : AbstractValidator<DeleteStaffQuery>
    {
        public DeleteStaffQueryValidator()
        {
            //Id 0'dan büyük olmalıdır
            RuleFor(command => command.StaffId).GreaterThan(0);
        }
    }
}
