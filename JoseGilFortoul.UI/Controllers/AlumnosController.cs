using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class AlumnosController : Controller
    {
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.AlumnoBussiness alumno = new Bussiness.AlumnoBussiness();
        private static Bussiness.PaisBussiness pais = new Bussiness.PaisBussiness();
        private static Bussiness.ProvinciaEstadoBussiness estado = new Bussiness.ProvinciaEstadoBussiness();
        private static Bussiness.PeriodoEscolarBussiness periodo = new Bussiness.PeriodoEscolarBussiness();
        private static Bussiness.GradoEscolarBussiness grado = new Bussiness.GradoEscolarBussiness();
        private static Bussiness.EstadoCivilBussines estadoCivil = new Bussiness.EstadoCivilBussines();
        private static Bussiness.DireccionBussiness direccion = new Bussiness.DireccionBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();
        private static Alumno model;
        private static List<Alumno> models;
        private static Representante modelRepresentante;

        public async Task<ActionResult> Index()
        {
            if (System.Web.HttpContext.Current.Session["ID"].ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
                ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

                models = new List<Models.Alumno>();
                models = await alumno.GetByRepresentative(modelRepresentante.Id);

                return View(models);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            ViewBag.Pais = await pais.GetAll();
            ViewBag.Estado = await estado.GetAll();
            ViewBag.PeriodoEscolar = await periodo.GetAll();
            ViewBag.Grado = await grado.GetAll();
            ViewBag.EstadoCivil = await estadoCivil.GetAll();
            model = new Alumno();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Update(Guid id)
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            ViewBag.Pais = await pais.GetAll();
            ViewBag.Estado = await estado.GetAll();
            ViewBag.PeriodoEscolar = await periodo.GetAll();
            ViewBag.Grado = await grado.GetAll();
            ViewBag.EstadoCivil = await estadoCivil.GetAll();
            model = new Alumno();
            model = await alumno.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Update(Alumno vm)
        {
            if (await alumno.UpdateEntity(vm))
            {
                TempData["Success"] = "Se ha actualizado su perfil exitosamente";
                return RedirectToAction("", "");
            }
            else
            {
                TempData["Error"] = "No se pudo actualizar su perfil. Inténtelo de nuevo";
                ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
                ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

                ViewBag.Pais = await pais.GetAll();
                ViewBag.Estado = await estado.GetAll();
                ViewBag.PeriodoEscolar = await periodo.GetAll();
                ViewBag.Grado = await grado.GetAll();
                ViewBag.EstadoCivil = await estadoCivil.GetAll();
                model = new Alumno();
                model = await alumno.GetById(vm.Id);
                return View(model);
            }
        }
    }
}