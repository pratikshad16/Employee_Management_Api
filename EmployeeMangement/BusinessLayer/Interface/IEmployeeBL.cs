using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface IEmployeeBL
    {
        public List<EmployeeDetails> GetEmployee();
        public bool AddEmployee(EmployeeDetails employee);
        public bool DeleteEmployeeById(string id);
        public bool EditEmployee(string id, EmployeeDetails employee);
        public List<EmployeeDetails> GetEmployeeById(string id);
    }
}
