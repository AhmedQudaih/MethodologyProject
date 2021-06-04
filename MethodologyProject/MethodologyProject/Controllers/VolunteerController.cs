using MethodologyProject.Models;
using MethodologyProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MethodologyProject.Controllers
{
    public class VolunteerController : Controller
    {
        private ConnectionContext db = new ConnectionContext();
        // GET: Volunteer
        public ActionResult Index()
        {
            ExperimentVolunteer ev = new ExperimentVolunteer { 
                Volunteers = db.Volunteers.ToList(),
                UserRole = db.UserRole.ToList()
            };
        
            return View(ev);
        }

        // GET: Volunteer/Details/5
        public ActionResult Details(int id)
        {
            var Volunteer = db.Volunteers.Single(Vol => Vol.national_id == id);
            ExperimentVolunteer ev = new ExperimentVolunteer
            {
                MyVolunteer = Volunteer,
                MyUserRole = db.UserRole.Single(ur => ur.id == Volunteer.UserRole_id)
            };
            var Myexperiment = db.Experiments.Where(ex => ex.id == Volunteer.experiment_id).ToList();

            if (Myexperiment.Count != 0) {
                ev.MyExperiment = Myexperiment.First();
            }

            return View(ev);
        }

        // GET: Volunteer/Create
        public ActionResult Create()
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "1")
            { 
            return View();
            }
            return RedirectToAction("Index");

        }

        // POST: Volunteer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var userid = Int32.Parse(Request.Form["national_id"]);
            if (db.Volunteers.Where(vol => vol.national_id == userid).Count() == 0 ) {
            Volunteer Vol = new Volunteer
            {
                national_id = userid,
                name = Request.Form["name"],
                age = Int16.Parse(Request.Form["age"]),
                note = Request.Form["note"],
                phone_number = Request.Form["phone_number"],
                address = Request.Form["address"],
                UserRole_id = Int16.Parse(Request.Form["UserRole"]),
                Password = Request.Form["Password"],
            };
             
            db.Volunteers.Add(Vol);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            return RedirectToAction("Login");
        }

        // GET: Volunteer/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "2")
            {
                var editevol = db.Volunteers.Single(vol => vol.national_id == id);
                return View(editevol);

            }
            return RedirectToAction("Index");
           
        }

        // POST: Volunteer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var editevol = db.Volunteers.Single(vol => vol.national_id == id);
            editevol.national_id = Int32.Parse(Request.Form["national_id"]);
            editevol.name = Request.Form["name"];
            editevol.age = Int16.Parse(Request.Form["age"].ToString());
            editevol.note = Request.Form["note"];
            editevol.phone_number = Request.Form["phone_number"];
            editevol.address = Request.Form["address"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "1")
            {
                var delvol = db.Volunteers.Single(vol => vol.national_id == id);
                db.Volunteers.Remove(delvol);
                db.SaveChanges();
               
            }
            return RedirectToAction("Index");

           
        }

        public ActionResult BlockVolunteer(int id)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "1")
            {
                var BlockVol = db.Volunteers.Single(ex => ex.national_id == id);
                BlockVol.Status = !BlockVol.Status;
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}
