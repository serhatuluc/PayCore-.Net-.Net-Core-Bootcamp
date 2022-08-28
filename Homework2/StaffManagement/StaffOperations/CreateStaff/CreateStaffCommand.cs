using StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.CreateStaff
{
    public class CreateStaffCommand
    {
        private readonly List<Staff> _StaffList;
        public CreateStaffModel Model { get; set; }
        public CreateStaffCommand(List<Staff> StaffList)
        {
            _StaffList = StaffList;
        }

        public void Handle()
        {
            //Handle metodu Model ile aldığı inputları yeni bir Staff nesnesine dönüştürüp listeye ekler.
            //Kullanıcıdan alınan inputların doğrudan nesne oluşturmak için kullanılmadı. Öncelikle modele değerler atandı.
            //Sonrasında ise model kullanılarak nesne oluşturuldu.
            var staff = _StaffList.SingleOrDefault(x => x.name == Model.name);

            //eğer staff listede bulunuyorsa exception fırlatır
            if (staff is not null)
            {
                throw new InvalidOperationException("Staff exists");
            }

            //nesne oluşturularak listeye atılır
            staff = new Staff();
            staff.id = Model.id;
            staff.name = Model.name;
            staff.lastname = Model.lastname;
            staff.email = Model.email;
            staff.dateOfBirth = Model.dateOfBirth;
            staff.phoneNumber = Model.phoneNumber;
            staff.salary = Model.salary;
            _StaffList.Add(staff);
        }
    }

    public class CreateStaffModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public double salary { get; set; }
    }
}

