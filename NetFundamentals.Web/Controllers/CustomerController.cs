using NetFundamentals.Model;
using NetFundamentals.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFundamentals.Web.Controllers
{
    public class CustomerController : Controller
    {
        private IRepository<Customer> repository;
        public CustomerController()
        {
            repository = new BaseRepository<Customer>();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(repository.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid) return View(customer);
            repository.Add(customer);
            return RedirectToAction("Index");
        }

    }
}