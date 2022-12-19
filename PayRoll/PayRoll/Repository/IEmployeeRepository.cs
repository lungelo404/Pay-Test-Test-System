using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Repository
{
    internal interface IEmployeeRepository
    {
        IQueryable<Employee > GetAll();
        Employee Get(int id);

        Employee GetById(int id);

    
        IQueryable<Employee> GetEmployeeByCounty(string county);
    }
}
