using Contry_State_City.Models;
using Contry_State_City.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contry_State_City.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext context;
        public RegisterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Register
        public ActionResult Index()
        {
            var userlist = context.Registers.Include(u => u.City).Include
                (u => u.City.State).Include(u => u.City.State.Country).ToList();
            return View(userlist);
        }
        public ActionResult Upsert(int? Id)
        {
            ViewBag.CntList = context.Countries.ToList();
            ViewBag.StaList = context.States.ToList();
            ViewBag.CtyList = context.Cities.ToList();
            Register register = new Register();
            if (Id == null) return View(register);
            register = context.Registers.Find(Id);
            if (register == null) return HttpNotFound();
            return View(register);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Register register)
        {
            if (register == null) return HttpNotFound();
            if(!ModelState.IsValid)
            {
                ViewBag.CntList = context.Countries.ToList();
                ViewBag.StaList = context.States.ToList();
                ViewBag.CtyList = context.Cities.ToList();
                return View(register);
            }
            if (register.Id == 0)
                context.Registers.Add(register);
            else
            {
                var userIndb = context.Registers.Find(register.Id);
                if (userIndb == null) return HttpNotFound();
                userIndb.Name = register.Name;
                userIndb.Address = register.Address;
                userIndb.Email = register.Email;
                userIndb.Gender = register.Gender;
                userIndb.IsSubscribe = register.IsSubscribe;
                userIndb.CityId = register.CityId;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int Id)
        {
            var userIndb = context.Registers.Include(u => u.City).Include(u => u.City.State).Include(u => u.City.State.Country).FirstOrDefault(u => u.Id == Id);
            return View(userIndb);
        }
        public ActionResult Delete(int Id)
        {
            var userIndb = context.Registers.Find(Id);
            if (userIndb == null) return HttpNotFound();
            context.Registers.Remove(userIndb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        #region APIs
        private List<State> GetStates(int countryId)
        {
            return context.States.Where(s => s.CountryId == countryId).ToList();
        }
        private List<City> GetCity(int stateId)
        {
            return context.Cities.Where(c => c.StateId == stateId).ToList();
        }
        public ActionResult LoadStateByCountryId(int countryId)
        {
            var stateList = GetStates(countryId);
            var stateListData = stateList.Select(s1 => new SelectListItem()
            {
                Text = s1.Name,
                Value=s1.Id.ToString()
            });
            return Json(stateListData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadCityByStateId(int stateId)
        {
            var cityList = GetCity(stateId);
            var cityListData = cityList.Select(c1 => new SelectListItem()
            {
                Text=c1.Name,
                Value=c1.Id.ToString()
            });
            return Json(cityListData, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}