using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KayaBank_WepApiCrudMVC.Models;

namespace KayaBank_WepApiCrudMVC.Controllers
{
    public class DebtController : Controller
    {
        // GET: Debt
        public ActionResult Index()
        {
            IEnumerable<Debt> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("DebtInformations").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<Debt>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {

                return View(new Debt());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("DebtInformations/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Debt>().Result);

            }
        }
        [HttpPost]
        public ActionResult Add(Debt Debt)
        {
            if (Debt.DebtNumber == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("DebtInformations/", Debt).Result;
                TempData["SuccessMessage"] = "başarılı şekilde kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("DebtInformations/" + Debt.DebtNumber, Debt).Result;
                TempData["SuccessMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("DebtInformations/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }






    }
}