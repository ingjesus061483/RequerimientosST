using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Requerimientos_ST.Models;
using Requerimientos_ST.Helpers;

namespace Requerimientos_ST.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index(int ? IdRequerimiento)
        {
            try
            {
                RequerimientoModelo ModeloRetornar = Funciones.Busqueda(IdRequerimiento);
                return View(ModeloRetornar);
            }
            catch (Exception ex)
            {
                return JavaScript($"alert('Ha ocurrido un error {ex.Message} ');");
            }
       
        }

        public ActionResult InsertarRequerimiento(RequerimientoModelo ModeloTrabajar)
        {
            try
            {
                List<RequerimientoBuscarModelo> ModeloRetornar = Funciones.AccionesRequerimientos(ModeloTrabajar);
                return View(ModeloRetornar);

            }
            catch (Exception ex)
            {
                return JavaScript($"alert('Vuelva a intentarlo{ex.Message}');");
            }
       
        }

        public ActionResult EliminarRequerimiento(int IdRequerimiento)
        {
            try
            {
                List<RequerimientoBuscarModelo> ModeloRetornar = Funciones.EliminarRequerimiento(IdRequerimiento);
                return View("../Principal/InsertarRequerimiento", ModeloRetornar);
            }
            catch (Exception ex)
            {
                return JavaScript($"alert('Ha ocurrido un error {ex.Message } ');");
            }
        }        
    }
}