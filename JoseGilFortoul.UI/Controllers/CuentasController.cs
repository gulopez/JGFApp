using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class CuentasController : Controller
    {
        private static Bussiness.UsuarioBussiness usuario = new Bussiness.UsuarioBussiness();
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.PaisBussiness pais = new Bussiness.PaisBussiness();
        private static Bussiness.ProvinciaEstadoBussiness estado = new Bussiness.ProvinciaEstadoBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();
        private static Models.Usuario model;
        private static Models.EstadoProvincia modelEstado;
        private static Models.Representante modelRepresentante;

        [HttpGet]
        public async Task<ActionResult> ChangePassword()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(string passActual, string passNuevo, string passConfirm)
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            if (passActual == passNuevo)
            {
                TempData["Error"] = "La contraseña nueva no puede ser igual a la anterior.";
                return View();
            }

            if (passNuevo != passConfirm)
            {
                TempData["Error"] = "Por favor verifique que la contraseña sea igual.";
                return View();
            }

            model = new Models.Usuario();
            model = await usuario.GetById(System.Web.HttpContext.Current.Session["CID"].ToString());

            if (usuario.GetHashingPass(passActual) != model.Clave)
            {
                TempData["Error"] = "La contraseña actual no coincide con la ingresada.";
                return View();
            }

            if (await usuario.ChangePassword(model, passNuevo))
            {
                TempData["Success"] = "Su contraseña se ha modificado exitosamente";
                return View();
            }
            else
            {
                TempData["Error"] = "No se pudo cambiar la contraseña. Inténtelo de nuevo";
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> UpdateRepresentative()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            ViewBag.Pais = await pais.GetAll();
            ViewBag.Estado = await estado.GetAll();

            Models.Representante modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CardID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            return View(modelRepresentante);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRepresentative(Models.Representante vm)
        {
            if (await representante.UpdateEntity(vm))
            {
                TempData["Success"] = "Se ha actualizado su perfil exitosamente";
            }
            else
            {
                TempData["Error"] = "No se pudo actualizar su perfil. Inténtelo de nuevo";
            }

            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            ViewBag.Pais = await pais.GetAll();
            ViewBag.Estado = await estado.GetAll();

            Models.Representante modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CardID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            return View(modelRepresentante);
        }
    }
}