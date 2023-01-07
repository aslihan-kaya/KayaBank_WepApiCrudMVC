using KayaBank_WepApiCrudMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KayaBank_WepApiCrudMVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            IEnumerable<Payment> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Payments").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<Payment>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {

                return View(new Payment());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Payments/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Payment>().Result);

            }
        }
        [HttpPost]
        public ActionResult Add(Payment Payment)
        {
            if (Payment.PaymentNumber == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Payments/", Payment).Result;
                TempData["SuccessMessage"] = "başarılı şekilde kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Payments/" + Payment.PaymentNumber, Payment).Result;
                TempData["SuccessMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Payments/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }






    }
}