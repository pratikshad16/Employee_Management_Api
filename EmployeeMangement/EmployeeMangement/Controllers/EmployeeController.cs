using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeBL businessLayer;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="businessLayer">To Ascess all properties of IEmployeeBL</param>
        public EmployeeController(IEmployeeBL businessLayer)
        {
            this.businessLayer = businessLayer;
        }
        [HttpGet]

        public IActionResult Display()
        {
            try
            {
                var result = this.businessLayer.GetEmployee();
                if (!result.Equals(null))
                    return this.Ok(new { success = true, message = "displayed all records,..successfully..", data = result });
                else
                    return this.BadRequest(new { success = false, message = "No records present", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
      
        [HttpPost]
       
        public IActionResult AddEmployee(EmployeeDetails employee)
        {
            try
            {
                bool result = this.businessLayer.AddEmployee(employee);
                if (result == true)
                    return this.Ok(new { success = true, message = "Record added", data = result });
                else
                    return this.BadRequest(new { success = false, message = "Record not added" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpDelete("{id:length(24)}")]
       
        public IActionResult Delete(string id)

        {
            try
            {
                bool result = this.businessLayer.DeleteEmployeeById(id);

                if (result == true)
                    return this.Ok(new { sucess = true, message = "Record deleted" });
                else
                    return this.BadRequest(new { sucess = false, message = "Record not deleted" });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpPut("{id:length(24)}")]
       
        public IActionResult Update(String id, EmployeeDetails employee)
        {
            try
            {
                bool result = this.businessLayer.EditEmployee(id, employee);

                if (result == true)
                    return this.Ok(new { sucess = true, message = "Record updated" });
                else
                    return this.BadRequest(new { sucess = false, message = "Record not updated" });

            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
        [HttpGet("{id:length(24)}")]

        public IActionResult GetEmployeeById(string id)
        {
            try
            {
                var result = this.businessLayer.GetEmployeeById(id);
                if (result != null)
                    return this.Ok(new { success = true, message = "displayed all records,..successfully..", data = result });
                else
                    return this.BadRequest(new { success = false, message = "No records present", data = result });
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
