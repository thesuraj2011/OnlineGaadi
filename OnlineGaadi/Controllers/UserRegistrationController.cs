using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGaadi.Models;
using OnlineGaadi.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGaadi.Controllers
{
    public class UserRegistrationController : Controller
    {
        // GET: UserRegistrationProp
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegistrationProp userRegistration)
        {
            try
            {
                UserRegistrationRepo userRegistrationRepo = new UserRegistrationRepo();
                userRegistrationRepo.RegistrationUser(userRegistration);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: DriverRegistrationController/Details/5
        public ActionResult DriverDetails(string driverLocation)
        {
            if (driverLocation == "" || driverLocation == null)
            {
                driverLocation = "All";
            }
            DriverRegistrationRepo driverRegistrationRepo = new DriverRegistrationRepo();
            return View(driverRegistrationRepo.FindDriverByLocation(driverLocation));
        }

        [HttpPost]
        public ActionResult FindDriverByLocation(string driverLocation)
        {
            if (driverLocation == "" || driverLocation == null)
            {
                driverLocation = "All";
            }
            DriverRegistrationRepo driverRegistrationRepo = new DriverRegistrationRepo();
            return View("DriverDetails", driverRegistrationRepo.FindDriverByLocation(driverLocation));
        }


        // GET: UserRegistrationProp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserRegistrationProp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRegistrationProp/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistrationProp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRegistrationProp/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserRegistrationProp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRegistrationProp/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
