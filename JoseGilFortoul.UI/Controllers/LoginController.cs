using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class LoginController : Controller
    {
        private static Bussiness.UsuarioBussiness usuario = new Bussiness.UsuarioBussiness();
        private static Models.Usuario model;
        private static List<Models.Usuario> models;
        private static Models.Representante modelRepresentante;
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string mail, string pass)
        {
            model = new Models.Usuario();
            model = await usuario.DoLogin(mail, pass);

            if (model.Id != Guid.Empty)
            {
                System.Web.HttpContext.Current.Session["CID"] = model.CedulaIdentidad;
                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(model.CedulaIdentidad);
                int total = await carrito.GetTotal(modelRepresentante.Id);
                System.Web.HttpContext.Current.Session["ShoppingCar"] = total.ToString();
                if (modelRepresentante.CedulaRepresentante != null)
                {
                    System.Web.HttpContext.Current.Session["Usuario"] = $"{modelRepresentante.PrimerNombre} {modelRepresentante.PrimerApellido}";
                    System.Web.HttpContext.Current.Session["CardID"] = modelRepresentante.CedulaRepresentante;
                    System.Web.HttpContext.Current.Session["ID"] = modelRepresentante.Id.ToString();
                }
                else
                {
                    System.Web.HttpContext.Current.Session["Usuario"] = $"{model.Nombre} {model.Apellido}";
                    System.Web.HttpContext.Current.Session["CardID"] = "";
                    System.Web.HttpContext.Current.Session["ID"] = "";
                }
                System.Web.HttpContext.Current.Session["Perfil"] = model.Perfil.Nombre;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "El usuario y/o contraseña es incorrecto";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(string nombre, string apellido, string mail, string confirmMail, string cardId, string pass, string confirmPass)
        {
            if (mail != confirmMail)
            {
                TempData["Error"] = "Por favor verifique que el correo sea igual";
                return View();
            }

            if (pass != confirmPass)
            {
                TempData["Error"] = "Por favor verifique que la contraseña sea igual";
                return View();
            }

            if (await usuario.Register(nombre, apellido, mail, cardId, pass))
            {
                TempData["Success"] = "Se ha registrado exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "No se pudo registrar el usuario. Inténtelo de nuevo";
                return View();
            }
        }

        public ActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Recover(string mail)
        {
            if (!await usuario.Recover(mail))
            {
                TempData["Error"] = "No existe el correo ingresado";
                return View();
            }

            model = new Models.Usuario();
            model = await usuario.GetByEmail(mail);
            return RedirectToAction("ChangePassword", "Login", model);
        }

        public ActionResult ConfirmMail()
        {
            return View();
        }

        public async Task<ActionResult> ChangePassword(Models.Usuario vm)
        {
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(Guid id, string pass, string passConfirm)
        {
            if (pass != passConfirm)
            {
                TempData["Error"] = "Por favor verifique que la contraseña sea igual";
                return View();
            }

            model = new Models.Usuario();
            model = await usuario.GetById(id);
            if (await usuario.ChangePassword(model, pass))
            {
                TempData["Success"] = "Se ha cambiado la contraseña exitosamente";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Error"] = "No se pudo cambiar la contraseña. Inténtelo de nuevo";
                return View();
            }
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session["Usuario"] = "";
            System.Web.HttpContext.Current.Session["CardID"] = "";
            System.Web.HttpContext.Current.Session["Perfil"] = "";

            return RedirectToAction("Index");
        }
    }
}