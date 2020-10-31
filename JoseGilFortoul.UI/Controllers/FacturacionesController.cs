using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace JoseGilFortoul.UI.Controllers
{
    public class FacturacionesController : Controller
    {
        private static Bussiness.FormasDePagoBussiness formasDePago = new Bussiness.FormasDePagoBussiness();
        private static Bussiness.PagoMasterBussiness pagoMaster = new Bussiness.PagoMasterBussiness();
        private static Bussiness.PeriodoEscolarBussiness periodo = new Bussiness.PeriodoEscolarBussiness();
        private static Bussiness.AlumnoBussiness alumno = new Bussiness.AlumnoBussiness();
        private static Bussiness.RepresentanteBussiness representante = new Bussiness.RepresentanteBussiness();
        private static Bussiness.ConceptoPagoBussiness conceptoPago = new Bussiness.ConceptoPagoBussiness();
        private static Bussiness.MesEscolarBussiness mes = new Bussiness.MesEscolarBussiness();
        private static Bussiness.CarritoCompraBussiness carrito = new Bussiness.CarritoCompraBussiness();
        private static Bussiness.PagoDetalladoBussiness pagoDetallado = new Bussiness.PagoDetalladoBussiness();
        private static Models.PagoMaster model;
        private static List<Models.PagoMaster> models;
        private static Models.Alumno modelAlumno;
        private static List<Models.Alumno> modelAlumnos;
        private static Models.Representante modelRepresentante;
        private static Models.CarritoCompra modelCarrito;
        private static List<Models.CarritoCompra> modelCarritos;
        private static Models.PagoDetallado modelPagoDetallado;
        private static List<Models.PagoDetallado> modelPagosDetallados;
        private static Models.PagoMaster modelPagoMaster;
        private static List<Models.PagoMaster> modelPagosMaster;

        public async Task<ActionResult> Pagos()
        {
            //ViewBag.ConceptoPago = await;
            ViewBag.PeriodoEscolar = await periodo.GetAll();
            ViewBag.MetodosPago = await formasDePago.GetAll();
            //model

            return View();
        }

        public async Task<ActionResult> DetallePagos()
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
                modelPagosMaster = new List<Models.PagoMaster>();
                modelPagosMaster = await pagoMaster.GetAllByRepresentative(modelRepresentante.Id);

                return View(modelPagosMaster);
            }
        }

        [HttpGet]
        public async Task<ActionResult> RealizarPago()
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

                ViewBag.Periodos = await periodo.GetAll();
                ViewBag.Conceptos = await conceptoPago.GetAll();
                ViewBag.Meses = await mes.GetAll();

                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
                modelAlumnos = new List<Models.Alumno>();
                modelAlumnos = await alumno.GetByRepresentative(modelRepresentante.Id);

                return View(modelAlumnos);
            }
        }

        [HttpPost]
        public async Task<ActionResult> RealizarPago(Guid id, Guid idPeriodoEscolar, Guid idConceptoPago, Guid? idMesEscolar, string comentario)
        {
            if (System.Web.HttpContext.Current.Session["ID"].ToString() == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (await carrito.SaveEntity(carrito.MatchModel(id, idPeriodoEscolar, idConceptoPago, idMesEscolar)))
                {
                    ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                    ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                    ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;

                    ViewBag.Periodos = await periodo.GetAll();
                    ViewBag.Conceptos = await conceptoPago.GetAll();
                    ViewBag.Meses = await mes.GetAll();

                    modelRepresentante = new Models.Representante();
                    modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                    int total = await carrito.GetTotal(modelRepresentante.Id);
                    System.Web.HttpContext.Current.Session["ShoppingCar"] = total.ToString();
                    ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
                    modelAlumnos = new List<Models.Alumno>();
                    modelAlumnos = await alumno.GetByRepresentative(modelRepresentante.Id);
                    ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                    TempData["Success"] = "Se ha agregado al carrito exitosamente";

                    return View(modelAlumnos);
                }
                else
                {
                    ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                    ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                    ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
                    ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                    ViewBag.Periodos = await periodo.GetAll();
                    ViewBag.Conceptos = await conceptoPago.GetAll();
                    ViewBag.Meses = await mes.GetAll();

                    modelRepresentante = new Models.Representante();
                    modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                    modelAlumnos = new List<Models.Alumno>();
                    modelAlumnos = await alumno.GetByRepresentative(modelRepresentante.Id);

                    TempData["Error"] = "No se pudo agregar al carrito. Inténtelo de nuevo.";

                    return View(modelAlumnos);
                }                
            }
        }

        [HttpGet]
        public async Task<ActionResult> PagarCarrito()
        {
            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.FormaPago = await formasDePago.GetAll();
            decimal monto = 0;
            foreach (var item in modelCarritos)
            {
               monto += item.MontoPagar;
            }
            ViewBag.Total = monto.ToString("N");

            return View(modelCarritos);
        }

        [HttpPost]
        public async Task<ActionResult> PagarCarrito(Guid idFormaPago, string referencia, decimal monto)
        {
            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            if (await pagoDetallado.SaveEntity(pagoDetallado.MatchModel(idFormaPago, referencia, monto, modelRepresentante.Id)))
            {
                TempData["Success"] = "Se ha agregado el método de pago exitosamente";
            }
            else
            {
                TempData["Error"] = "No se pudo agregar el método de pago exitosamente";
            }

            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.FormaPago = await formasDePago.GetAll();
            decimal montoPagar = 0;
            foreach (var item in modelCarritos)
            {
                montoPagar += item.MontoPagar;
            }
            ViewBag.Total = montoPagar.ToString("N");

            return View(modelCarritos);
        }

        public async Task<ActionResult> EliminarCarrito(Guid id)
        {
            if (await carrito.DeleteEntity(id))
            {
                TempData["Success"] = "Se ha eliminado el concepto de pago del carrito exitosamente";
            }
            else
            {
                TempData["Error"] = "No se pudo eliminar el concepto de pago del carrito";
            }

            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            int total = await carrito.GetTotal(modelRepresentante.Id);
            System.Web.HttpContext.Current.Session["ShoppingCar"] = total.ToString();
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;
            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.FormaPago = await formasDePago.GetAll();
            decimal montoPagar = 0;
            foreach (var item in modelCarritos)
            {
                montoPagar += item.MontoPagar;
            }
            ViewBag.Total = montoPagar;

            return RedirectToAction("PagarCarrito", "Facturaciones", modelCarritos);
        }

        public async Task<ActionResult> EliminarPago(Guid id)
        {
            if (await pagoDetallado.DeleteEntity(id))
            {
                TempData["Success"] = "Se ha eliminado el método de pago exitosamente";
            }
            else
            {
                TempData["Error"] = "No se pudo eliminar el método de pago";
            }

            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.FormaPago = await formasDePago.GetAll();
            decimal montoPagar = 0;
            foreach (var item in modelCarritos)
            {
                montoPagar += item.MontoPagar;
            }
            ViewBag.Total = montoPagar;

            return RedirectToAction("PagarCarrito", "Facturaciones", modelCarritos);
        }

        [ChildActionOnly]
        public ActionResult _ListaPago()
        {
            modelRepresentante = new Models.Representante();
            modelRepresentante = representante.GetByCardIdSync(System.Web.HttpContext.Current.Session["CID"].ToString());
            modelPagosDetallados = new List<Models.PagoDetallado>();
            modelPagosDetallados = Task.Run(async () => await pagoDetallado.GetByRepresentative(modelRepresentante.Id)).Result;
            decimal monto = 0;
            foreach (var item in modelPagosDetallados)
            {
                monto += item.Monto;
            }
            ViewBag.Total = monto.ToString("N");

            return PartialView(modelPagosDetallados);
        }

        public async Task<ActionResult> Pagar()
        {
            modelRepresentante = new Models.Representante();
            modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            decimal montoCarrito = await carrito.GetTotalAmount(modelRepresentante.Id);
            decimal montoPago = await pagoDetallado.GetTotalAmount(modelRepresentante.Id);
            if (montoCarrito > montoPago)
            {
                TempData["Error"] = "Los montos de los pagos cargados no completan el monto a pagar";
                ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
                ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                modelCarritos = new List<Models.CarritoCompra>();
                modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
                ViewBag.FormaPago = await formasDePago.GetAll();
                decimal monto = 0;
                foreach (var item in modelCarritos)
                {
                    monto += item.MontoPagar;
                }
                ViewBag.Total = monto.ToString("N");
                return RedirectToAction("PagarCarrito", "Facturaciones", modelCarritos);
            }
            if (montoPago > montoCarrito)
            {
                TempData["Error"] = "Los montos de los pagos cargados superan el monto a pagar";
                ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
                ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
                ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
                ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

                modelRepresentante = new Models.Representante();
                modelRepresentante = await representante.GetByCardId(System.Web.HttpContext.Current.Session["CID"].ToString());
                modelCarritos = new List<Models.CarritoCompra>();
                modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
                ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
                ViewBag.FormaPago = await formasDePago.GetAll();
                decimal monto = 0;
                foreach (var item in modelCarritos)
                {
                    monto += item.MontoPagar;
                }
                ViewBag.Total = monto.ToString("N");
                return RedirectToAction("PagarCarrito", "Facturaciones", modelCarritos);
            }

            Guid id = Guid.NewGuid();
            int error = 0;
            foreach (var item in modelCarritos)
            {
                if (!await pagoMaster.SaveEntity(pagoMaster.MatchModel(id, item.IdAlumno, item.IdPeriodoEscolar, item.IdConceptoPago, item.IdMesEscolar, item.MontoPagar)))
                {
                    error += 1;
                }
                else
                {
                    await carrito.DeleteEntity(item.Id);
                }
            }

            if (error == 0)
            {
                TempData["Success"] = "Se han agregado los pagos exitosamente";
            }

            ViewData["Usuario"] = System.Web.HttpContext.Current.Session["Usuario"] as string;
            ViewData["Perfil"] = System.Web.HttpContext.Current.Session["Perfil"] as string;
            ViewData["CardID"] = System.Web.HttpContext.Current.Session["CardID"] as string;
            ViewData["ShoppingCar"] = System.Web.HttpContext.Current.Session["ShoppingCar"] as string;

            modelCarritos = new List<Models.CarritoCompra>();
            modelCarritos = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.Carrito = await carrito.GetByRepresentative(modelRepresentante.Id);
            ViewBag.FormaPago = await formasDePago.GetAll();
            decimal montoPagar = 0;
            foreach (var item in modelCarritos)
            {
                montoPagar += item.MontoPagar;
            }
            ViewBag.Total = montoPagar;

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> VerificarPago()
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

                modelPagosDetallados = new List<Models.PagoDetallado>();
                modelPagosDetallados = await pagoDetallado.GetAll();

                return View(modelPagosDetallados);
            }
        }
    }
}