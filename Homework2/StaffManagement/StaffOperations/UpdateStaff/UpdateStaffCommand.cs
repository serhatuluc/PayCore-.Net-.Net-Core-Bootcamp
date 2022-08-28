using StaffManagement.Controllers;
using StaffManagement.StaffOperations.CreateStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.UpdateStaff
{
    public class UpdateStaffCommand
    {
        private readonly List<Staff> _StaffList;

        //Model kullanımı tercih edildi.
        public UpdateStaffModel Model { get; set; }

        //Kullanıcıdan staff id alındı.
        public int StaffId { get; set; }

        public UpdateStaffCommand(List<Staff> StaffList)
        {
            _StaffList = StaffList;
        }

        public void Handle()
        {
            //Handle metodu Model ile aldığı inputları var olan Staff nesnesinde günceller
            var staff = _StaffList.Single(x => x.id == StaffId);

            //Eğer staff bulunmuyorsa hata döndürür
            if (staff is null)
            {
                throw new InvalidOperationException("Güncellenecek staff bulunamadı");
            }

            //Eğer kullanıcı değer girmediyse değişmeyecek şekilde kodlandı. Örneğin kullanıcın sadece adını değiştirebilir.
            staff.name = Model.name != default ? Model.name : staff.name;
            staff.lastname = Model.lastname != default ? Model.lastname : staff.lastname;
            staff.email = Model.email != default ? Model.email : staff.email;
            staff.dateOfBirth = Model.dateOfBirth != default ? Model.dateOfBirth : staff.dateOfBirth;
            staff.phoneNumber = Model.phoneNumber != default ? Model.phoneNumber : staff.phoneNumber;
            staff.salary = Model.salary != default ? Model.salary : staff.salary;
        }
    }
    public class UpdateStaffModel
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
