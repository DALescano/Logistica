using Logistica.Entidades;
using Logistica.Servicios.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Logistica.Framework;

namespace Logistica.Presentacion.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IAdministracionServicio _administracionServicio;

        public PrincipalController(IAdministracionServicio administracionServicio)
        {
            this._administracionServicio = administracionServicio;
        }

        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {
            var tt =_administracionServicio.RegistrarCategoria(new CategoriaRequest()
            { 
                idCategoria = Guid.NewGuid()
            });
            return View();
        }

        public ActionResult DashBoard()
        {
            return View();
        }
    }
}