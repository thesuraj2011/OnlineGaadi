using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGaadi.Models;
using OnlineGaadi.Repo;

namespace OnlineGaadi.Controllers
{
    public class DriverRegistrationController : Controller
    {
        // GET: DriverRegistrationController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DriverRegistrationProp driverRegistration)
        {
            try
            {
                DriverRegistrationRepo driverRegistrationRepo = new DriverRegistrationRepo();
                driverRegistrationRepo.RegistrationDriver(driverRegistration);

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
            return View("DriverDetails",driverRegistrationRepo.FindDriverByLocation(driverLocation));
        }

        // GET: DriverRegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DriverRegistrationController/Edit/5
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

        // GET: DriverRegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DriverRegistrationController/Delete/5
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
