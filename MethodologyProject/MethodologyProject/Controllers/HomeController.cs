using MethodologyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MethodologyProject.Controllers
{
    public class HomeController : Controller
    {
        private ConnectionContext db = new ConnectionContext();
        public ActionResult Login()
        {
            if (Session["UserRole"] != null) {
                return Redirect("/Experiment/Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            
            var nid = Int32.Parse(Request.Form["national_id"].ToString());
            var Password = Request.Form["Password"];
            var volunteer =  db.Volunteers.Single(vol => vol.national_id == nid && vol.Password == Password);
            if (volunteer != null)
            {
                Session["UserRole"] = volunteer.UserRole_id;
                return Redirect("/Experiment/Index");
            }
            return RedirectToAction("Login");

        }

        public ActionResult Logout()
        {
            if (Session["UserRole"] != null)
            {
                Session.Abandon();
            }
            return RedirectToAction("Login");
        }


    }
}