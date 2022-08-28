using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    public class Staff 
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
