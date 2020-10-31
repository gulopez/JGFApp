using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class HomeController : Controller
    {
        private static Models.Representante modelRepresentante;
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();

        public async Task<ActionResult> Index()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            if (!String.IsNullOrEmpty(System.Web.HttpContext.Current.Session["CID"].ToString()))
            {
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            }            

            return View();
        }
    }
}