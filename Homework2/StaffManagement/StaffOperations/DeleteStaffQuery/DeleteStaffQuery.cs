using StaffManagement.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.StaffOperations.DeleteStaffQuery
{
    public class DeleteStaffQuery
    {
        private readonly List<Staff> _StaffList;

       //Kullanıcıdan sadece staff id'si alınır. Burada model kullanma ihtiyacı duyulmadı.
        public int StaffId { get; set; }
        public DeleteStaffQuery(List<Staff> StaffList)
        {
            _StaffList = StaffList;
        }
        public void Handle()
        {
            //Handle metodu id ile eşleşen staffı siler.
            var staff = _StaffList.SingleOrDefault(x => x.id == StaffId);

            //Eğer id uyuşmuyorsa staff bulunamadı hatası verir.
            if (staff is null)
            {
                throw new InvalidOperationException("Staff bulunamadı");
            }
            _StaffList.Remove(staff);
            
        }
    }
}
