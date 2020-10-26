using CommonLayer.Model;
using MongoDB.Driver;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Service
{
    public class EmployeeRL: IEmployeeRL
    {
        private readonly IMongoCollection<EmployeeDetails> _Employee;
        public EmployeeRL(IEmployeeDataBaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _Employee = database.GetCollection<EmployeeDetails>(settings.EmployeeCollectionName);
        }
        public List<EmployeeDetails> GetEmployee()
        {
            try
            {
                return this._Employee.Find(employee => true).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool AddEmployee(EmployeeDetails employee)
        {
            try
            {
                EmployeeDetails newEmployee = new EmployeeDetails()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Password = employee.Password
                };
                _Employee.InsertOne(newEmployee);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool DeleteEmployeeById(string id)
        {
            try
            {
                _Employee.DeleteOne(employee => employee.Id == id);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool EditEmployee(string id, EmployeeDetails employee)
        {
            try
            {

                _Employee.ReplaceOne(employee => employee.Id == id, employee);
                return true;
            }
            catch { return false; }
        }
        public List<EmployeeDetails> GetEmployeeById(string id)
        {
            try
            {
                return _Employee.Find<EmployeeDetails>(employee => employee.Id == id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
