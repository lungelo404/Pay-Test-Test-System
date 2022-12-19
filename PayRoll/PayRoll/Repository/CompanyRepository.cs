using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayRoll.Repository
{
    public class CompanyRepository : ICompanyRepository
    {

        private ApplicationDbContext _context;

        public CompanyRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IQueryable<Company> GetCompanies()
        {
          
            return _context.Companies.OrderBy(n => n.Name).AsQueryable();
        }

        public Company GetCompanyById(int id)
        {
           
            
         List<Company> companies = _context.Companies.ToList();
         List<Address> addresses = _context.Addresses.ToList();
         List<Employee> employees = _context.Employees.ToList();

            var objCompany = (from company in companies
                              join address in addresses on company.BusinessAddressID equals address.ID
                              where company.ID == id
                              select new Company
                              {
                                  Employees = company.Employees,
                                  BusinessAddress = address,
                                  Name = company.Name,
                                  ID = company.ID
                              }).FirstOrDefault();

         return objCompany;
        }

        public Company GetCompanyDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}