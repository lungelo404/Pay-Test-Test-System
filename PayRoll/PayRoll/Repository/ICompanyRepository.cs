using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayRoll.Models;

namespace PayRoll.Repository
{
    internal interface ICompanyRepository
    {
        IQueryable<Company> GetCompanies();

        Company GetCompanyById(int id);

        Company GetCompanyDetails(int id);


    }
}
