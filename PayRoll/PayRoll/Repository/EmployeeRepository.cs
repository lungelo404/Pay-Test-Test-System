using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace PayRoll.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;

        public EmployeeRepository()
        {
            _context = new ApplicationDbContext();
        }
        public Employee Get(int id)
        {
            return _context.Employees.SingleOrDefault(model => model.ID == id);
        }

        public IQueryable<Employee> GetAll()
        {

            List<Address> addresses = _context.Addresses.ToList();
            List<Employee> employees = _context.Employees.ToList();


            var objEmployee = (from Employee in employees
                               join address in addresses on Employee.HomeAddressID equals address.ID
                               select new Employee
                               {
                                   ID = Employee.ID,
                                   Name = Employee.Name,
                                   Position = Employee.Position,
                                   HomeAddress = address,
                                   Lastname = Employee.Lastname,
                                   CompanyID = Employee.CompanyID,

                               }).AsQueryable();


            return objEmployee.AsQueryable();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }


        public IQueryable<Employee> GetEmployeeByCounty(string county)
        {
            List<Address> addresses = _context.Addresses.Where(n => n.Country == county).ToList();
            List<Employee> employees = _context.Employees.ToList();

            var objEmployee = (from Employee in employees
                               join address in addresses on Employee.HomeAddressID equals address.ID
                               select new Employee
                               {
                                   ID = Employee.ID,
                                   Name = Employee.Name,
                                   Position = Employee.Position,
                                   HomeAddress = address,
                                   Lastname = Employee.Lastname,
                                   CompanyID = Employee.CompanyID,

                               }).AsQueryable();
            return objEmployee;
        }

    }
}