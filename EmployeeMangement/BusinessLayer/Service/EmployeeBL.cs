using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class EmployeeBL: IEmployeeBL
    {
        private IEmployeeRL repositoryLayer;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="repositoryLayer"></param>
        public EmployeeBL(IEmployeeRL repositoryLayer)
        {
            try
            {
                this.repositoryLayer = repositoryLayer;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool AddEmployee(EmployeeDetails employee)
        {
            return this.repositoryLayer.AddEmployee(employee);
        }
        public bool DeleteEmployeeById(string id)
        {
            return this.repositoryLayer.DeleteEmployeeById(id);
        }
        public bool EditEmployee(string id, EmployeeDetails employee)
        {
            return this.repositoryLayer.EditEmployee(id, employee);
        }
        public List<EmployeeDetails> GetEmployee()
        {

            try
            {
                return this.repositoryLayer.GetEmployee();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<EmployeeDetails> GetEmployeeById(string id)
        {

            try
            {
                return this.repositoryLayer.GetEmployeeById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
