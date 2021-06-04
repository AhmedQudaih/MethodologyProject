using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MethodologyProject.Models;
using MethodologyProject.ViewModel;

namespace MethodologyProject.Controllers
{

    public class ExperimentController : Controller
    {
        private ConnectionContext db = new ConnectionContext();
        // GET: Experiment
        public ActionResult Index()
        {
            ExperimentVolunteer EV = new ExperimentVolunteer
            {
                Volunteers = db.Volunteers.ToList(),
                Experiments = db.Experiments.ToList()
            };

            return View(EV);
        }

        // GET: Experiment/Details/5
        public ActionResult Details(int id)
        {
            ExperimentVolunteer EV = new ExperimentVolunteer { 
            Volunteers = db.Volunteers.Where(vol => vol.experiment_id == id).ToList(),
            MyExperiment = db.Experiments.Single(ex => ex.id == id)
        };
            return View(EV);
        }

        // GET: Experiment/Create
        public ActionResult Create() 
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "2")
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Experiment ex = new Experiment { 
            name = Request.Form["name"],
            description = Request.Form["description"],
            start_date = Request.Form["start_date"],
            end_date = Request.Form["end_date"],    
            };
            db.Experiments.Add(ex);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        // GET: Experiment/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "2") { 
            var editex = db.Experiments.Single(ex => ex.id == id);
                return View(editex);

            }
            return RedirectToAction("Index");

        }

        // POST: Experiment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var editex = db.Experiments.Single(ex => ex.id == id);
            editex.name = Request.Form["name"];
            editex.description = Request.Form["description"];
            editex.start_date = Request.Form["start_date"];
            editex.end_date = Request.Form["end_date"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Experiment/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["UserRole"] != null && Int64.Parse(Session["UserRole"].ToString()) == 2)
            {
                var delex = db.Experiments.Single(ex => ex.id == id);
                db.Experiments.Remove(delex);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult AssignToExperiment(int id)
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "2")
            {
                ExperimentVolunteer EV = new ExperimentVolunteer
                {
                    MyVolunteer = db.Volunteers.Single(ex => ex.national_id == id),
                    Experiments = db.Experiments.ToList()
                };
                return View(EV);
            }
            return RedirectToAction("Index");

        }



        [HttpPost]
        public ActionResult AssignToExperiment(FormCollection collection)
        {

            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "2")
            {
                var naid = Int32.Parse(Request.Form["national_id"]);
                var assigntoex = db.Volunteers.Single(ex => ex.national_id == naid);
                assigntoex.experiment_id = Int32.Parse(Request.Form["experiment_id"]);
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        public ActionResult GeneralReport()
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "1")
            {
                ExperimentVolunteer EV = new ExperimentVolunteer
                {
                    Volunteers = db.Volunteers.ToList(),
                    Experiments = db.Experiments.ToList()
                };

                return View(EV);
            }
            return RedirectToAction("Index");
        }

        public ActionResult SpecificReport()
        {
            if (Session["UserRole"] != null && Session["UserRole"].ToString() == "1")
            {
                ExperimentVolunteer EV = new ExperimentVolunteer
                {
                    Volunteers = db.Volunteers.ToList(),
                    Experiments = db.Experiments.ToList()
                };
                return View(EV);
            }
            return RedirectToAction("Index");
        }

    }
}
