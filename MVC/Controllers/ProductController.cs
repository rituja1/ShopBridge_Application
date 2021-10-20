using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<MVCProductModel> emplist;
            HttpResponseMessage response = Global_variables.WebApiClient.GetAsync("Product").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<MVCProductModel>>().Result;

            return View(emplist);
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if(id==0)
            {
                return View(new MVCProductModel());
            }
            else
            {
                HttpResponseMessage response = Global_variables.WebApiClient.GetAsync("Product/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCProductModel>().Result);
            }
               
        }
        [HttpPost]
        public ActionResult AddorEdit(MVCProductModel pdt)
        {

            if(!ModelState.IsValid)
            {
                TempData["success"] = "Please fill all fields";
                return View();

            }
            if(pdt.ProductID==0)
            {
                HttpResponseMessage response = Global_variables.WebApiClient.PostAsJsonAsync("Product", pdt).Result;
                TempData["success"] = "saved successfully";
                return RedirectToAction("Index");
            }
            else
            {
                HttpResponseMessage response = Global_variables.WebApiClient.PutAsJsonAsync("Product/" + pdt.ProductID.ToString(), pdt).Result;
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");

            }
            
        }

        public ActionResult Delete(int id = 0)
        {
            HttpResponseMessage response = Global_variables.WebApiClient.DeleteAsync("Product/" + id.ToString()).Result;
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }

    }
}