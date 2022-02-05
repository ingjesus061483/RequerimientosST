using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Requerimientos_ST.Entidades;

namespace Requerimientos_ST.Helpers
{
    public class Funciones
    {
        public static SelectList GetActividadesList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {

                    var query_sql = contexto.Areas.AsQueryable();

                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre }).Distinct().ToList();


                }
            }
            catch (Exception ex)
            {
                result = new List<SelectListItem>();
            }

            return new SelectList(result, "Value", "Text");
        }

        public static SelectList GetAplicativosList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {

                    var query_sql = contexto.Aplicativos.AsQueryable();

                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre }).Distinct().ToList();


                }
            }
            catch (Exception ex)
            {
                result = new List<SelectListItem>();
            }

            return new SelectList(result, "Value", "Text");
        }

        public static SelectList GetPrioridadesList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {

                    var query_sql = contexto.Prioridades.AsQueryable();

                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre }).Distinct().ToList();


                }
            }
            catch (Exception ex)
            {
                result = new List<SelectListItem>();
            }

            return new SelectList(result, "Value", "Text");
        }

        public static SelectList GetDesarrolladoresList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {

                    var query_sql = contexto.Desarrolladores.AsQueryable();

                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre }).Distinct().ToList();


                }
            }
            catch (Exception ex)
            {
                result = new List<SelectListItem>();
            }

            return new SelectList(result, "Value", "Text");
        }

        public static DateTime GetFechaPruebaByFechaDesarrollo(DateTime FechaDesarrollo,DateTime FechaSolicitud)
        {
            DateTime FechaPrueba;

            var Dias = (FechaDesarrollo - FechaSolicitud).Days;
            int DiasPrueba = Convert.ToInt32(Dias/2);
            FechaPrueba = FechaDesarrollo.AddDays(DiasPrueba);
            return FechaPrueba;
        }
    }
}