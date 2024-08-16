using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using task5.Models;

namespace task5.Controllers
{
    public class DetailsController : Controller
    {
        private Repository _repository = new Repository();
        private IEnumerable<object> model;

        [HttpGet]
        public ActionResult Index()
        {
            // Initialize ViewBag.States and ViewBag.Cities
            ViewBag.States = new SelectList(_repository.GetStates(), "StateId", "StateName");
            ViewBag.Cities = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            //  ViewBag.Cities = new SelectList(_repository.GetCities(StateId), "Value", "Text");
            //  ViewBag.Cities = Details.StateId > 0 ? GetCities(candidate.StateId) : new List<City>();
            // Initialize model
            var model = new Details();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Details s)
        {
            if (ModelState.IsValid)
            {
                _repository.Register(s);
                return RedirectToAction("Success");
            }

            // Re-populate ViewBag on failed validation
            ViewBag.States = new SelectList(_repository.GetStates(), "StateId", "StateName");
            ViewBag.Cities = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
           
            return View(s);
        }

        [HttpGet]
        public JsonResult GetCitiesByStateId(string stateId)
        {
            if (string.IsNullOrEmpty(stateId))
            {
                return Json(new List<City>(), JsonRequestBehavior.AllowGet);
            }

            var cities = _repository.GetCities(stateId);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]


        public ActionResult GetDetails(string searchString, string CountryId, int? Page, int pageSize = 3)
        {
            Details obj = new Details();
            obj.pagesize = pageSize;
            int currentPage = Page ?? 1;
            int totalCount;

            var model = _repository.GetPagedData(obj.pagesize, currentPage, out totalCount).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(r => r.Name.Contains(searchString)).ToList();
            }

           

          
            int totalPages = (totalCount / pageSize);
            ViewBag.TotalCount = totalCount;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;

            return View(model);
        }


        //public ActionResult GetDetails(string searchstring)
        //{
        //    if (!string.IsNullOrEmpty(searchstring))
        //    {
        //        model = model.Where(r => r.Name.Contains(searchstring)).ToList();
        //    }

        //    ModelState.Clear();
        //    return View(_repository.GetDetails());
        //}
    }
}
