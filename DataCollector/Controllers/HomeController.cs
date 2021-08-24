using DataCollector.Helpers;
using FeatureVectors.Classes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DataCollector.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            List<FeatureVector> vectors = VectorHelper.GenerateVectors();

            return View();
        }










        //// Validation for input
        //public JsonResult ItemExists(string itemName)
        //{
        //    bool result = true;
        //    ItemOrchestrator orch = new ItemOrchestrator();

        //    Item existingItem = orch.GetItemByName(itemName);

        //    if (existingItem == null)
        //    {
        //        result = false;
        //    }
        //    return Json(result);

        //    // return whether the item name already exists or not

        //}


    }
}