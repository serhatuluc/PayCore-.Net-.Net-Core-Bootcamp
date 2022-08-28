using StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.GetStaff
{
    public class GetStaffQuery
    {
        private readonly List<Staff> _StaffList;
        public GetStaffQuery(List<Staff> StaffList)
        {
            _StaffList = StaffList;
        }

        public List<StaffViewModel> Handle()
        {
            //Handle metodu listede bulunan staff nesneleri id ye göre sıralar. ModelView kullanılmıştır.
            var StaffList = _StaffList.OrderBy(x => x.id).ToList<Staff>();

            //View model nesnesi oluşturuldu.
            List<StaffViewModel> vm = new List<StaffViewModel>();
            //Listedeki her eleman viewmodel ile eşlenerek döndürüldü.
            foreach(var staff in _StaffList)
            {
                vm.Add(new StaffViewModel()
                {
                    id = staff.id,
                    name = staff.name,
                    lastname = staff.lastname,
                    dateOfBirth = staff.dateOfBirth.ToString("dd/MM/yy"),
                    email = staff.email,
                    phoneNumber = staff.phoneNumber,
                    salary = staff.salary
                });
            }
            return vm;
        }
    }

    public class StaffViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string dateOfBirth { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public double salary { get; set; }
    }
}
