using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KayaBank_WepApiCrudMVC.Models;

namespace KayaBank_WepApiCrudMVC.Controllers
{
    public class BranchController : Controller
    {
        // GET: Pages
        public ActionResult Index()
        {
            IEnumerable<Branch> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("BrachInformations").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<Branch>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {

                return View(new Branch());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("BrachInformations/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Branch>().Result);

            }
        }
        [HttpPost]
        public ActionResult Add(Branch branch)
        {
            if (branch.BranchNo == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("BrachInformations", branch).Result;
                TempData["SuccessMessage"] = "başarılı şekilde kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("BrachInformations/" + branch.BranchNo, branch).Result;
                TempData["SuccessMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("BrachInformations/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }






    }
}