using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KayaBank_WepApiCrudMVC.Models;

namespace KayaBank_WepApiCrudMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
      
        public ActionResult Index()
        {
            IEnumerable<Customer> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("CustomerInformations").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<Customer>>().Result;
            return View(calList);
            //return View();
        }
        public ActionResult Add(int id = 0)
        {
            if (id == 0)
            {

                return View(new Customer());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("CustomerInformations/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<Customer>().Result);

            }
        }
        [HttpPost]
        public ActionResult Add(Customer Customer)
        {
            if (Customer.CustomerNumber == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("CustomerInformations/", Customer).Result;
                TempData["SuccessMessage"] = "başarılı şekilde kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("CustomerInformations/" + Customer.CustomerNumber, Customer).Result;
                TempData["SuccessMessage"] = "update başarılı";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("CustomerInformations/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "silme başarılı";
            return RedirectToAction("Index");
        }






    }
}