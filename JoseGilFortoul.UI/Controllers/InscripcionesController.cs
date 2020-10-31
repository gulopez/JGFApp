using JoseGilFortoul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class InscripcionesController : Controller
    {
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.AlumnoBussiness alumno = new Bussiness.AlumnoBussiness();
        private static Bussiness.PaisBussiness pais = new Bussiness.PaisBussiness();
        private static Bussiness.ProvinciaEstadoBussiness provinciaEstado = new Bussiness.ProvinciaEstadoBussiness();
        private static Bussiness.PeriodoEscolarBussiness periodo = new Bussiness.PeriodoEscolarBussiness();
        private static Bussiness.GradoEscolarBussiness grado = new Bussiness.GradoEscolarBussiness();
        private static Bussiness.EstadoCivilBussines estadoCivil = new Bussiness.EstadoCivilBussines();
        private static Bussiness.PreInscripcionBussiness preInscripcion = new Bussiness.PreInscripcionBussiness();
        private static Bussiness.SolicitudCupoBussiness cupo = new Bussiness.SolicitudCupoBussiness();
        private static Bussiness.UsuarioBussiness usuario = new Bussiness.UsuarioBussiness();
        private static Bussiness.EstadoBussiness estado = new Bussiness.EstadoBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();
        private static Bussiness.SeccionBussiness seccion = new Bussiness.SeccionBussiness();
        private static Alumno model;
        private static List<Alumno> models;
        private static SolicitudCupo modelCupo;
        private static List<SolicitudCupo> modelsCupo;
        private static Representante modelRepresentante;
        private static Estado modelEstado;

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

                modelRepresentante = new Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

                models = new List<Alumno>();
                if (System.Web.HttpContext.Current.Session["Perfil"].ToString() == "Administrador")
                {
                    models = await alumno.GetByPreInscription();
                }
                else
                {
                    models = await alumno.GetByRepresentative(modelRepresentante.Id);
                }                

                return View(models);
            }
        }

        [HttpGet]
        public async Task<ActionResult> PreInscripcion(Guid id)
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            ViewBag.Cursos = await grado.GetAll();
            ViewBag.Periodos = await periodo.GetAll();
            model = await alumno.GetById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> PreInscripcion(Guid id, string comentario, Guid idGrado, Guid idPeriodo, Guid idRepresentante)
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

                Usuario user = await usuario.GetById(System.Web.HttpContext.Current.Session["CID"].ToString());
                if (await preInscripcion.Save(id, comentario, idGrado, idPeriodo, user.Id, idRepresentante))
                {
                    TempData["Success"] = "La PreInscripción fue guardada exitosamente";

                    return RedirectToAction("Index", "Inscripciones");
                }
                else
                {
                    model = new Alumno();
                    model = await alumno.GetById(id);
                    ViewBag.Cursos = await grado.GetAll();
                    ViewBag.Periodos = await periodo.GetAll();
                    TempData["Error"] = "No se pudo guardar la PreInscripción. Inténtelo de nuevo.";

                    return View(model);
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> CuposSolicitados()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            modelsCupo = new List<SolicitudCupo>();
            if (System.Web.HttpContext.Current.Session["Perfil"].ToString() == "Administrador")
            {
                modelsCupo = await cupo.GetAll();
            }
            else
            {
                Usuario user = await usuario.GetById(System.Web.HttpContext.Current.Session["CID"].ToString());
                modelsCupo = await cupo.GetByUsuario(user.Id);
            }
            

            return View(modelsCupo);
        }

        [HttpGet]
        public async Task<ActionResult> SolicitarCupo()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            ViewBag.Pais = await pais.GetAll();
            ViewBag.Estado = await provinciaEstado.GetAll();
            ViewBag.PeriodoEscolar = await periodo.GetAll();
            ViewBag.Grado = await grado.GetAll();
            ViewBag.EstadoCivil = await estadoCivil.GetAll();
            model = new Alumno();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SolicitarCupo(Alumno vm, int tipoRepresentante, int representanteLegal)
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

                modelRepresentante = new Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

                Usuario user = await usuario.GetById(System.Web.HttpContext.Current.Session["CID"].ToString());
                
                if (await alumno.ExistsEntity(string.IsNullOrEmpty(vm.CedulaAlumno) ? vm.CarnetEstudiante : vm.CedulaAlumno ))
                {

                    //Validate if an existing solicitud exists and show the bellow error message
                    // TempData["Error"] = "Ya existe una solicitud de cupo para la cédula o carnet ingresado.";
                    //or continue

                     //Student may be retired and returning
                    //Step 1 Get existing Student by Cedula or carnet de estudiante, 
                    //Step 2 Update existing information with information being submitted
                    vm = await alumno.MatchModel(vm, tipoRepresentante, modelRepresentante, representanteLegal);

                    //Step Create solicitud de Cupo

                    modelCupo = new SolicitudCupo();
                    modelCupo = await cupo.MatchModel(modelCupo, user.Id, vm);
                    if (await cupo.SaveEntity(modelCupo))
                    {
                        TempData["Success"] = "La solicitud fue guardada exitosamente";
                    }

                    //Validate if an existing solicitud exists and show the bellow error message
                    // TempData["Error"] = "Ya existe una solicitud de cupo para la cédula o carnet ingresado.";
                }
                else
                {
                    vm = await alumno.MatchModel(vm, tipoRepresentante, modelRepresentante, representanteLegal);
                    if (await alumno.SaveEntity(vm))
                    {
                        modelCupo = new SolicitudCupo();
                        modelCupo = await cupo.MatchModel(modelCupo, user.Id, vm);
                        if (await cupo.SaveEntity(modelCupo))
                        {
                            TempData["Success"] = "La solicitud fue guardada exitosamente";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "No se pudo guardar la solicitud. Inténtelo de nuevo.";
                    }
                }

                modelsCupo = new List<SolicitudCupo>();
                modelsCupo = await cupo.GetByUsuario(user.Id);
                return RedirectToAction("CuposSolicitados", modelsCupo);
            }
        }

        [HttpGet]
        public async Task<ActionResult> VisualizarDetalle(Guid id)
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);

            model = new Alumno();
            model = await alumno.GetById(id);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Aprobar(Guid id)
        {
            modelCupo = new SolicitudCupo();
            modelCupo = await cupo.GetByAlumno(id);
            Estado modelEstado = new Estado();
            modelEstado = await estado.GetByName("Aprobado");
            modelCupo.IdEstado = modelEstado.Id;
            modelCupo.Estado = null;
            modelCupo.GradoEscolar = null;
            modelCupo.PeriodoEscolar = null;
            if (await cupo.UpdateEntity(modelCupo))
            {
                TempData["Success"] = "Se aprobó exitosamente la solicitud";
            }
            else
            {
                TempData["Error"] = "No se pudo aprobar la solicitud. Inténtelo de nuevo.";
            }

            return RedirectToAction("CuposSolicitados", "Inscripciones");
        }

        [HttpGet]
        public async Task<ActionResult> Rechazar(Guid id)
        {
            modelCupo = new SolicitudCupo();
            modelCupo = await cupo.GetByAlumno(id);
            Estado modelEstado = new Estado();
            modelEstado = await estado.GetByName("Rechazado");
            modelCupo.IdEstado = modelEstado.Id;
            Guid idAlumno = modelCupo.IdAlumno.Value;
            modelCupo.IdAlumno = null;
            modelCupo.Estado = null;
            modelCupo.GradoEscolar = null;
            modelCupo.PeriodoEscolar = null;
            if (await cupo.UpdateEntity(modelCupo))
            {
                await alumno.DeleteEntity(idAlumno);
                TempData["Success"] = "Se rechazo exitosamente la solicitud";
            }
            else
            {
                TempData["Error"] = "No se pudo rechazar la solicitud. Inténtelo de nuevo.";
            }

            return RedirectToAction("CuposSolicitados", "Inscripciones");
        }

        [HttpGet]
        public ActionResult Inscripcion()
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

                models = new List<Alumno>();

                return View(models);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Inscripcion(string cedulaCarnet)
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

                models = new List<Alumno>();
                models = await alumno.GetByKeyword(cedulaCarnet);

                return View(models);
            }
        }

        [HttpGet]
        public async Task<ActionResult> ProcesarInscripcion(Guid id)
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;

            model = new Alumno();
            model = await alumno.GetById(id);

            ViewBag.Seccion = await seccion.GetAll();

            return View(model);
        }
    }
}