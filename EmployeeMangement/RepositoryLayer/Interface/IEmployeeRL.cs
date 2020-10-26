using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IEmployeeRL
    {
        public List<EmployeeDetails> GetEmployee();
        bool AddEmployee(EmployeeDetails employee);
        bool DeleteEmployeeById(string id);
        bool EditEmployee(string id, EmployeeDetails employee);
        public List<EmployeeDetails> GetEmployeeById(string id);
    }
}
