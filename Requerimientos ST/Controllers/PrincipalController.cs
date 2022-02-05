using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Requerimientos_ST.Models;
using Requerimientos_ST.Entidades;
using Requerimientos_ST.Helpers;

namespace Requerimientos_ST.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index(int ? IdRequerimiento)
        {
            if (IdRequerimiento > 0)
            {
                using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
                {
                    try
                    {
                        RequerimientoModelo ModeloRetornar = new RequerimientoModelo();
                        ModeloRetornar = contexto.Requerimientos.Where(x => x.Id == IdRequerimiento).Select(y => new RequerimientoModelo { Alcance = y.Alcance, Area = y.Area, Aplicativo = y.Aplicativo, FechaSolicitud = y.FechaSolicitud, Prioridad = y.Prioridad, Desarrollador = y.Desarrollador, FechaDesarrollo = y.FechaDesarrollo, FechaPrueba = y.FechaPrueba, Id = y.Id }).FirstOrDefault();

                        return View(ModeloRetornar);

                    }
                    catch (Exception ex)
                    {
                        return JavaScript("alert('Vuelva a intentarlo ');");
                    }

                }
            }
            return View(new RequerimientoModelo());
        }

        public ActionResult InsertarRequerimiento(RequerimientoModelo ModeloTrabajar)
        {
            using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
            {
                try
                {
                    List<RequerimientoBuscarModelo> ModeloRetornar = new List<RequerimientoBuscarModelo>();

                    if (ModeloTrabajar.BtnAccion == "Insertar")
                    {
                        contexto.Pro_Insert_Requerimiento(ModeloTrabajar.Area, ModeloTrabajar.Aplicativo, ModeloTrabajar.Alcance, ModeloTrabajar.FechaSolicitud, ModeloTrabajar.Prioridad, ModeloTrabajar.Desarrollador, ModeloTrabajar.FechaDesarrollo,Funciones.GetFechaPruebaByFechaDesarrollo(Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo), Convert.ToDateTime(ModeloTrabajar.FechaSolicitud)));

                        ModeloRetornar.AddRange(contexto.Requerimientos.Select(x => new RequerimientoBuscarModelo { alcance = x.Alcance, Aplicativo = x.Aplicativos.Nombre, Area = x.Areas.Nombre, Desarrollador = x.Desarrolladores.Nombre, FechaDesarrollo = x.FechaDesarrollo, FechaPrueba = x.FechaPrueba, FechaSolicitud = x.FechaSolicitud, Prioridad = x.Prioridades.Nombre, Id = x.Id }).ToList());

                    }
                    else
                    {
                        if (ModeloTrabajar.BtnAccion == "Editar")
                        {
                            if(ModeloTrabajar.Id>0)
                            {
                                contexto.Pro_Editar_Requerimiento(ModeloTrabajar.Id,ModeloTrabajar.Area, ModeloTrabajar.Aplicativo, ModeloTrabajar.Alcance, ModeloTrabajar.FechaSolicitud, ModeloTrabajar.Prioridad, ModeloTrabajar.Desarrollador, ModeloTrabajar.NuevaFechaDesarrollo , Funciones.GetFechaPruebaByFechaDesarrollo(Convert.ToDateTime(ModeloTrabajar.NuevaFechaDesarrollo ), Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo )),ModeloTrabajar.MotivoCambio ,ModeloTrabajar .Justificacion );
                                ModeloRetornar.AddRange(contexto.Requerimientos.Select(x => new RequerimientoBuscarModelo { alcance = x.Alcance, Aplicativo = x.Aplicativos.Nombre, Area = x.Areas.Nombre, Desarrollador = x.Desarrolladores.Nombre, FechaDesarrollo = x.FechaDesarrollo, FechaPrueba = x.FechaPrueba, FechaSolicitud = x.FechaSolicitud, Prioridad = x.Prioridades.Nombre, Id = x.Id }).ToList());
                               
                            }
                            else
                            {
                                return JavaScript("alert('Debe primero seleccionar un requerimiento ');");
                            }
                        }
                        else
                        {
                            var ListaRequerimientos = contexto.Pro_Buscar_Requerimientos(ModeloTrabajar.Area, ModeloTrabajar.Aplicativo, ModeloTrabajar.Alcance, ModeloTrabajar.FechaSolicitud, ModeloTrabajar.Prioridad, ModeloTrabajar.Desarrollador, ModeloTrabajar.FechaDesarrollo, Funciones.GetFechaPruebaByFechaDesarrollo(Convert.ToDateTime(ModeloTrabajar.FechaDesarrollo), Convert.ToDateTime(ModeloTrabajar.FechaSolicitud)),ModeloTrabajar.MotivoCambio );

                            foreach(var registro in ListaRequerimientos)
                            {
                                RequerimientoBuscarModelo NuevoRequerimiento = new RequerimientoBuscarModelo();
                                NuevoRequerimiento.alcance = registro.Alcance;
                                NuevoRequerimiento.Aplicativo = registro.aplicativo;
                                NuevoRequerimiento.Area = registro.area;
                                NuevoRequerimiento.Desarrollador = registro.desarrollador;
                                NuevoRequerimiento.FechaDesarrollo = registro.FechaDesarrollo;
                                NuevoRequerimiento.FechaPrueba = registro.FechaPrueba;
                                NuevoRequerimiento.FechaSolicitud = registro.FechaSolicitud;
                                NuevoRequerimiento.Id = registro.Id;
                                NuevoRequerimiento.Prioridad = registro.prioridad;
                                ModeloRetornar.Add(NuevoRequerimiento);
                            }

                        }
                    }
                    return View(ModeloRetornar);

                }
                catch (Exception ex)
                {
                    return JavaScript("alert('Vuelva a intentarlo ');");
                }

            }



        }

        public ActionResult EliminarRequerimiento(int IdRequerimiento)
        {
            using (PruebaTecnicaEntities contexto = new PruebaTecnicaEntities())
            {
                try
                {
                    List<RequerimientoBuscarModelo> ModeloRetornar = new List<RequerimientoBuscarModelo>();

                    contexto.Pro_Eliminar_Requerimiento(IdRequerimiento);

                    ModeloRetornar.AddRange(contexto.Requerimientos.Select(x => new RequerimientoBuscarModelo { alcance = x.Alcance, Aplicativo = x.Aplicativos.Nombre, Area = x.Areas.Nombre, Desarrollador = x.Desarrolladores.Nombre, FechaDesarrollo = x.FechaDesarrollo, FechaPrueba = x.FechaPrueba, FechaSolicitud = x.FechaSolicitud, Prioridad = x.Prioridades.Nombre, Id = x.Id }).ToList());

                    return View("../Principal/InsertarRequerimiento", ModeloRetornar);

                }
                catch (Exception ex)
                {
                    return JavaScript("alert('Vuelva a intentarlo ');");
                }

            }



        }

        
    }
}