using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.StaffOperations.CreateStaff;
using StaffManagement.StaffOperations.DeleteStaffQuery;
using StaffManagement.StaffOperations.GetStaff;
using StaffManagement.StaffOperations.GetStaffById;
using StaffManagement.StaffOperations.UpdateStaff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StaffManagement.Controllers
{
    [Route("/[controller]s")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        //Statik liste belierlendi, ekleme çıkarma işlemi bu liste üzerinde yapılacaktır.
        static List<Staff> StaffList = new List<Staff>() {new Staff
        (){
             id = 1,
             name = "Deny",
             lastname = "Sellen",
             dateOfBirth = new DateTime(1989,01,01),
             email = "deny@gmail.com",
             phoneNumber = "+905554446677",
             salary = 4450

        },new Staff
        (){
             id = 2,
             name = "Serhat",
             lastname = "Uluc",
             dateOfBirth = new DateTime(1997,01,01),
             email = "serhat@gmail.com",
             phoneNumber = "+905456478923",
             salary = 5600

        }};

        
       

        [HttpGet]
        public IActionResult GetStaffs()
        {
            //StaffOperations'ta oluşturulan sınıf kullanılarak işlemler yapılmıştır.
            GetStaffQuery query = new GetStaffQuery(StaffList);

            //Listedeki bütün objeleri döndürür.
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public IActionResult GetStaffsById([FromQuery] int id)
        {
            //StaffOperations'ta oluşturulan sınıf kullanılarak işlemler yapılmıştır.
            GetStaffByIdQuery query = new GetStaffByIdQuery(StaffList);

            //Id alındı.
            query.StaffId = id;

            //Viewmodel kullanılarak result döndürülecek.
            GetStaffByIdViewModel result;

            try
            {
                //Validator ile validation sağlandı.
                GetStaffByIdQueryValidator validator = new GetStaffByIdQueryValidator();
                validator.ValidateAndThrow(query);
                //View işlemi burada halledildi.
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddStaff([FromBody]CreateStaffModel newStaff)
        {
            CreateStaffCommand command = new CreateStaffCommand(StaffList);

            try
            {
                //Yeni staff Modelle eşlendi
                command.Model = newStaff;

                //FluentValidation validatoru kullanılarak validasyon sağlandı
                CreateStaffCommandValidator validator = new CreateStaffCommandValidator();
                var result = validator.Validate(command);

                //Errorları listeye alınır
                var errorList = new List<String>();

                if (!result.IsValid)
                {
                   foreach(var error in result.Errors)
                    {
                        errorList.Add(error.ErrorMessage);
                    }
                   //Errorlar liste olarak döndürüldü
                    return BadRequest(errorList);
                }
                else
                {
                    //Listeye ekleme işlemi error oluşmadıysa gerçekleştirilir
                    command.Handle();
                }


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
            return Ok();
        }


        [HttpDelete]
        public IActionResult DeleteStaff(int id)
        {
            DeleteStaffQuery query = new DeleteStaffQuery(StaffList);
            try
            {
                //Id alındı
                query.StaffId = id;
                //Vaildator kullanılarak validation sağlandı
                DeleteStaffQueryValidator validator = new DeleteStaffQueryValidator();
                validator.ValidateAndThrow(query);
                //İşlem burada gerçekleştirildi.
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id,[FromQuery] UpdateStaffModel updatedStaff)
        {
            try
            {
                UpdateStaffCommand command = new UpdateStaffCommand(StaffList);
                command.StaffId = id;
                command.Model = updatedStaff;

                //Handle işlemi gerçekleşmeden validasyon gerçekleştirildi
                UpdateStaffCommandValidator validator = new UpdateStaffCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }
    }
}
