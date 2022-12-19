using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PayRoll.Repository;
using PagedList;

namespace PayRoll.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository employeeRepository = new EmployeeRepository();
        private ICompanyRepository CompanyRepository = new CompanyRepository();
        private  const int pageSize = 10;
        private int pageIndex = 1;
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [Authorize]
        [OutputCache(CacheProfile = "Long")]
        public ActionResult ListAllCompanies(int? page)
        {
            try
            {
              
                return View(CompanyRepository.GetCompanies().ToPagedList(page ?? 1, pageSize));
              
            }
            catch
            {
               
                return View("Error");
            }

            

        }




        [Authorize]
        public ActionResult CompanyDetails(int? ID)
        {

            try
            {
                return View(CompanyRepository.GetCompanyById((int)ID));
            }
            catch
            {
                return View("Error");
            }
        }



        [Authorize]
        [HttpGet]
        [OutputCache(CacheProfile = "Long")]
        public ActionResult ListAllEmployees(int? page)
        {

            try
            {
                return View(employeeRepository.GetAll().ToPagedList(page ?? 1, pageSize));
            }catch
            {
                return View("Error");

            }
        }


        [Authorize]
        [HttpGet]
        [OutputCache(CacheProfile = "Short")]
        public ActionResult ListSouthAfricanEmployees(int? page)
        {

            try
            {
                return View(employeeRepository.GetEmployeeByCounty("South Africa").ToPagedList(page ?? 1, pageSize));
            }catch
            {
                return View("Error");
            }

        }




    }
}