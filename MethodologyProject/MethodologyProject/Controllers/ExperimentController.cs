using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MethodologyProject.Controllers
{
    public class ExperimentController : Controller
    {
        // GET: Experiment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Experiment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Experiment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Experiment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experiment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Experiment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Experiment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Experiment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AssignToExperiment()
        {

            return RedirectToAction("Index");
        }

        public ActionResult GeneralReport()
        { 
            return View();
        }

        public ActionResult SpecificReport()
        {
            return View();
        }

    }
}
