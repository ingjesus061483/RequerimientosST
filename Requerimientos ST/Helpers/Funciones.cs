using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Requerimientos_ST.Entidades;
using Requerimientos_ST.Models;
namespace Requerimientos_ST.Helpers
{
    public class Funciones
    {
        public static RequerimientoModelo Busqueda(int ?IdRequerimiento)
        {
            RequerimientoModelo ModeloRetornar = new RequerimientoModelo();
            if (IdRequerimiento > 0)
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {
                    try
                    {                    
                        ModeloRetornar = contexto.Requerimientos.Where(x => x.Id == IdRequerimiento)
                            .Select(y => new RequerimientoModelo { 
                                Alcance = y.Alcance, Area = y.Area, Aplicativo = y.Aplicativo, FechaSolicitud = y.FechaSolicitud,
                                Prioridad = y.Prioridad, Desarrollador = y.Desarrollador, FechaDesarrollo = y.FechaDesarrollo,
                                MotivoCambio=y.MotivoDeCambio,Justificacion =y.Justificacion ,
                                FechaPrueba = y.FechaPrueba, Id = y.Id 
                            }).FirstOrDefault();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }         
            }
            return ModeloRetornar;
        }
        public static  List<RequerimientoBuscarModelo> EliminarRequerimiento(int IdRequerimiento)
        {
            using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
            {
                try
                {
                    List<RequerimientoBuscarModelo> ModeloRetornar = new List<RequerimientoBuscarModelo>();
                    contexto.Pro_Eliminar_Requerimiento(IdRequerimiento);
                    ModeloRetornar.AddRange(contexto.Requerimientos.Select(x => new RequerimientoBuscarModelo {
                        alcance = x.Alcance, 
                        Aplicativo = x.Aplicativos.Nombre,
                        Area = x.Areas.Nombre,
                        Desarrollador = x.Desarrolladores.Nombre,
                        FechaDesarrollo = x.FechaDesarrollo,
                        FechaPrueba = x.FechaPrueba, 
                        FechaSolicitud = x.FechaSolicitud, 
                        Prioridad = x.Prioridades.Nombre, 
                        Id = x.Id }).ToList());
                    return ModeloRetornar;

                }
                catch (Exception ex)
                {
                   throw  ex;
                }
            }
        }
        public static List<RequerimientoBuscarModelo> AccionesRequerimientos(RequerimientoModelo ModeloTrabajar)
        {
            using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
            {
                try
                {
                    List<RequerimientoBuscarModelo> ModeloRetornar = new List<RequerimientoBuscarModelo>();
                    switch (ModeloTrabajar.BtnAccion)
                    {
                        case "Insertar":
                            {
                                DateTime fechaDesarrollo = Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo);
                                DateTime fechasolicitud = Convert.ToDateTime(ModeloTrabajar.FechaSolicitud);
                                DateTime fechaPrueba = GetFechaPruebaByFechaDesarrollo(fechaDesarrollo, fechasolicitud);

                                contexto.Pro_Insert_Requerimiento(ModeloTrabajar.Area, ModeloTrabajar.Aplicativo,
                                    ModeloTrabajar.Alcance, ModeloTrabajar.FechaSolicitud, ModeloTrabajar.Prioridad,
                                    ModeloTrabajar.Desarrollador, ModeloTrabajar.FechaDesarrollo,
                                    fechaPrueba);
                                ModeloRetornar.AddRange(contexto.Requerimientos
                                    .Select(x => new RequerimientoBuscarModelo { 
                                        alcance = x.Alcance,
                                        Aplicativo = x.Aplicativos.Nombre, 
                                        Area = x.Areas.Nombre,
                                        Desarrollador = x.Desarrolladores.Nombre,
                                        FechaDesarrollo = x.FechaDesarrollo, 
                                        FechaPrueba = x.FechaPrueba,
                                        FechaSolicitud = x.FechaSolicitud,
                                        Prioridad = x.Prioridades.Nombre, Id = x.Id 
                                    }).ToList());
                                break;
                            }
                        case "Editar":
                            {
                                DateTime fechaPrueba;
                                DateTime fechaDesarrollo;
                                if(ModeloTrabajar .NuevaFechaDesarrollo!=null)
                                {
                                    fechaDesarrollo = Convert.ToDateTime(ModeloTrabajar.NuevaFechaDesarrollo);
                                    fechaPrueba = GetFechaPruebaByFechaDesarrollo(Convert.ToDateTime(ModeloTrabajar.NuevaFechaDesarrollo), 
                                        Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo));
 
                                }
                                else
                                {
                                    fechaDesarrollo = Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo);
                                    fechaPrueba = Convert.ToDateTime(ModeloTrabajar.FechaPrueba);
                                }
                                contexto.Pro_Editar_Requerimiento(ModeloTrabajar.Id, ModeloTrabajar.Area,
                                    ModeloTrabajar.Aplicativo, 
                                    ModeloTrabajar.Alcance, ModeloTrabajar.FechaSolicitud,
                                    ModeloTrabajar.Prioridad, ModeloTrabajar.Desarrollador,
                                    fechaDesarrollo , fechaPrueba,ModeloTrabajar.MotivoCambio,
                                    ModeloTrabajar.Justificacion);

                                ModeloRetornar.AddRange(contexto.Requerimientos.Select(x => new RequerimientoBuscarModelo { alcance = x.Alcance, 
                                    Aplicativo = x.Aplicativos.Nombre, 
                                    Area = x.Areas.Nombre,
                                    Desarrollador = x.Desarrolladores.Nombre,                                     
                                    FechaDesarrollo = x.FechaDesarrollo, 
                                    FechaPrueba = x.FechaPrueba,
                                    FechaSolicitud = x.FechaSolicitud,
                                    Prioridad = x.Prioridades.Nombre, Id = x.Id }).ToList());
                                break;
                            }
                        case "Buscar":
                            {
                                var ListaRequerimientos = contexto.Pro_Buscar_Requerimientos(ModeloTrabajar.Area, 
                                    ModeloTrabajar.Aplicativo, ModeloTrabajar.Alcance, 
                                    ModeloTrabajar.FechaSolicitud, ModeloTrabajar.Prioridad, 
                                    ModeloTrabajar.Desarrollador, ModeloTrabajar.FechaDesarrollo, 
                                    ModeloTrabajar.MotivoCambio);
                                foreach (var registro in ListaRequerimientos)
                                {
                                    RequerimientoBuscarModelo NuevoRequerimiento = new RequerimientoBuscarModelo
                                    {
                                        alcance = registro.Alcance,
                                        Aplicativo = registro.aplicativo,
                                        Area = registro.area,
                                        Desarrollador = registro.desarrollador,
                                        FechaDesarrollo = registro.FechaDesarrollo,
                                        FechaPrueba = registro.FechaPrueba,
                                        FechaSolicitud = registro.FechaSolicitud,                                        
                                        Id = registro.Id,
                                       
                                        Prioridad = registro.prioridad
                                    };
                                    ModeloRetornar.Add(NuevoRequerimiento);
                                }
                                break;
                            }
                    }
                    return ModeloRetornar;

                }
                catch (Exception ex)
                {
                     throw ex;
                }
            }

        }
        public static SelectList GetActividadesList()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            try
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {

                    var query_sql = contexto.Areas.AsQueryable();
                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre })
                        .Distinct().ToList();
                }
            }
            catch 
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
                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre })
                        .Distinct().ToList();
                }
            }
            catch
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
                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre })
                        .Distinct().ToList();
                }
            }
            catch 
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
                    result = query_sql.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Nombre })
                        .Distinct().ToList();
                }
            }
            catch 
            {
                result = new List<SelectListItem>();
            }
            return new SelectList(result, "Value", "Text");
        }

        public static DateTime GetFechaPruebaByFechaDesarrollo(DateTime FechaDesarrollo,DateTime FechaSolicitud)
        {
            try
            {
                DateTime FechaPrueba;
                var Dias = (FechaDesarrollo - FechaSolicitud).Days;
                if(Dias <0)
                {
                    throw new Exception("fecha incorrecta");
                }
                int DiasPrueba = Convert.ToInt32(Dias / 2);
                FechaPrueba = FechaDesarrollo.AddDays(DiasPrueba);
                return FechaPrueba;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}