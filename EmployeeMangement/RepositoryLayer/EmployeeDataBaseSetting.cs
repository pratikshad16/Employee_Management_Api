using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
   public class EmployeeDataBaseSetting: IEmployeeDataBaseSetting
    {
        public string EmployeeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IEmployeeDataBaseSetting
    {
        string EmployeeCollectionName { get; set; }
        
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
