﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Requerimientos_ST.Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PruebaTecnicaEntities : DbContext
    {
        public PruebaTecnicaEntities()
            : base("name=PruebaTecnicaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Aplicativos> Aplicativos { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<Desarrolladores> Desarrolladores { get; set; }
        public virtual DbSet<Prioridades> Prioridades { get; set; }
        public virtual DbSet<Requerimientos> Requerimientos { get; set; }
    
        public virtual ObjectResult<Pro_Buscar_Requerimientos_Result> Pro_Buscar_Requerimientos(Nullable<int> area, Nullable<int> aplicativo, string alcance, Nullable<System.DateTime> fechaSolicitud, Nullable<int> prioridad, Nullable<int> desarrollador, Nullable<System.DateTime> fechaDesarrollo, Nullable<System.DateTime> fechaPrueba, string motivodecambio)
        {
            var areaParameter = area.HasValue ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(int));
    
            var aplicativoParameter = aplicativo.HasValue ?
                new ObjectParameter("Aplicativo", aplicativo) :
                new ObjectParameter("Aplicativo", typeof(int));
    
            var alcanceParameter = alcance != null ?
                new ObjectParameter("Alcance", alcance) :
                new ObjectParameter("Alcance", typeof(string));
    
            var fechaSolicitudParameter = fechaSolicitud.HasValue ?
                new ObjectParameter("FechaSolicitud", fechaSolicitud) :
                new ObjectParameter("FechaSolicitud", typeof(System.DateTime));
    
            var prioridadParameter = prioridad.HasValue ?
                new ObjectParameter("Prioridad", prioridad) :
                new ObjectParameter("Prioridad", typeof(int));
    
            var desarrolladorParameter = desarrollador.HasValue ?
                new ObjectParameter("Desarrollador", desarrollador) :
                new ObjectParameter("Desarrollador", typeof(int));
    
            var fechaDesarrolloParameter = fechaDesarrollo.HasValue ?
                new ObjectParameter("FechaDesarrollo", fechaDesarrollo) :
                new ObjectParameter("FechaDesarrollo", typeof(System.DateTime));
    
            var fechaPruebaParameter = fechaPrueba.HasValue ?
                new ObjectParameter("FechaPrueba", fechaPrueba) :
                new ObjectParameter("FechaPrueba", typeof(System.DateTime));
    
            var motivodecambioParameter = motivodecambio != null ?
                new ObjectParameter("motivodecambio", motivodecambio) :
                new ObjectParameter("motivodecambio", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Pro_Buscar_Requerimientos_Result>("Pro_Buscar_Requerimientos", areaParameter, aplicativoParameter, alcanceParameter, fechaSolicitudParameter, prioridadParameter, desarrolladorParameter, fechaDesarrolloParameter, fechaPruebaParameter, motivodecambioParameter);
        }
    
        public virtual int Pro_Editar_Requerimiento(Nullable<int> id, Nullable<int> area, Nullable<int> aplicativo, string alcance, Nullable<System.DateTime> fechaSolicitud, Nullable<int> prioridad, Nullable<int> desarrollador, Nullable<System.DateTime> fechaDesarrollo, Nullable<System.DateTime> fechaPrueba, string motivoDeCambio, string justificacion)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var areaParameter = area.HasValue ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(int));
    
            var aplicativoParameter = aplicativo.HasValue ?
                new ObjectParameter("Aplicativo", aplicativo) :
                new ObjectParameter("Aplicativo", typeof(int));
    
            var alcanceParameter = alcance != null ?
                new ObjectParameter("Alcance", alcance) :
                new ObjectParameter("Alcance", typeof(string));
    
            var fechaSolicitudParameter = fechaSolicitud.HasValue ?
                new ObjectParameter("FechaSolicitud", fechaSolicitud) :
                new ObjectParameter("FechaSolicitud", typeof(System.DateTime));
    
            var prioridadParameter = prioridad.HasValue ?
                new ObjectParameter("Prioridad", prioridad) :
                new ObjectParameter("Prioridad", typeof(int));
    
            var desarrolladorParameter = desarrollador.HasValue ?
                new ObjectParameter("Desarrollador", desarrollador) :
                new ObjectParameter("Desarrollador", typeof(int));
    
            var fechaDesarrolloParameter = fechaDesarrollo.HasValue ?
                new ObjectParameter("FechaDesarrollo", fechaDesarrollo) :
                new ObjectParameter("FechaDesarrollo", typeof(System.DateTime));
    
            var fechaPruebaParameter = fechaPrueba.HasValue ?
                new ObjectParameter("FechaPrueba", fechaPrueba) :
                new ObjectParameter("FechaPrueba", typeof(System.DateTime));
    
            var motivoDeCambioParameter = motivoDeCambio != null ?
                new ObjectParameter("motivoDeCambio", motivoDeCambio) :
                new ObjectParameter("motivoDeCambio", typeof(string));
    
            var justificacionParameter = justificacion != null ?
                new ObjectParameter("justificacion", justificacion) :
                new ObjectParameter("justificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pro_Editar_Requerimiento", idParameter, areaParameter, aplicativoParameter, alcanceParameter, fechaSolicitudParameter, prioridadParameter, desarrolladorParameter, fechaDesarrolloParameter, fechaPruebaParameter, motivoDeCambioParameter, justificacionParameter);
        }
    
        public virtual int Pro_Eliminar_Requerimiento(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pro_Eliminar_Requerimiento", idParameter);
        }
    
        public virtual int Pro_Insert_Requerimiento(Nullable<int> area, Nullable<int> aplicativo, string alcance, Nullable<System.DateTime> fechaSolicitud, Nullable<int> prioridad, Nullable<int> desarrollador, Nullable<System.DateTime> fechaDesarrollo, Nullable<System.DateTime> fechaPrueba)
        {
            var areaParameter = area.HasValue ?
                new ObjectParameter("Area", area) :
                new ObjectParameter("Area", typeof(int));
    
            var aplicativoParameter = aplicativo.HasValue ?
                new ObjectParameter("Aplicativo", aplicativo) :
                new ObjectParameter("Aplicativo", typeof(int));
    
            var alcanceParameter = alcance != null ?
                new ObjectParameter("Alcance", alcance) :
                new ObjectParameter("Alcance", typeof(string));
    
            var fechaSolicitudParameter = fechaSolicitud.HasValue ?
                new ObjectParameter("FechaSolicitud", fechaSolicitud) :
                new ObjectParameter("FechaSolicitud", typeof(System.DateTime));
    
            var prioridadParameter = prioridad.HasValue ?
                new ObjectParameter("Prioridad", prioridad) :
                new ObjectParameter("Prioridad", typeof(int));
    
            var desarrolladorParameter = desarrollador.HasValue ?
                new ObjectParameter("Desarrollador", desarrollador) :
                new ObjectParameter("Desarrollador", typeof(int));
    
            var fechaDesarrolloParameter = fechaDesarrollo.HasValue ?
                new ObjectParameter("FechaDesarrollo", fechaDesarrollo) :
                new ObjectParameter("FechaDesarrollo", typeof(System.DateTime));
    
            var fechaPruebaParameter = fechaPrueba.HasValue ?
                new ObjectParameter("FechaPrueba", fechaPrueba) :
                new ObjectParameter("FechaPrueba", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Pro_Insert_Requerimiento", areaParameter, aplicativoParameter, alcanceParameter, fechaSolicitudParameter, prioridadParameter, desarrolladorParameter, fechaDesarrolloParameter, fechaPruebaParameter);
        }
    }
}
