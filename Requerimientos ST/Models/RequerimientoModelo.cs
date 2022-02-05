using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Requerimientos_ST.Models
{
    public class RequerimientoModelo
    {
        [Required]
        [Display(Name = "Identificación")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Area")]
        public int? Area { get; set; }

        [Required]
        [Display(Name = "Aplicativo")]
        public int? Aplicativo { get; set; }

        [Required]
        [Display(Name = "Alcance")]
        public string Alcance { get; set; }

        [Required]
        [Display(Name = "Motivo de cambio")]
        public string MotivoCambio { get; set; }

        [Required]
        [Display(Name = "Justifcacion")]
        public string Justificacion { get; set; }
        [Required]
        [Display(Name = "Prioridad")]
        public int? Prioridad { get; set; }

        [Required]
        [Display(Name = "Desarrollador")]
        public int? Desarrollador { get; set; }

        
        [Display(Name = "Fecha solicitud")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaSolicitud { get; set; }
        
        [Display(Name = "Fecha desarrollo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDesarrollo { get; set; }

        [Display(Name = "Nueva Fecha de desarrollo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NuevaFechaDesarrollo { get; set; }

        [Display(Name = "Fecha prueba")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPrueba { get; set; }

        public string BtnAccion { get; set; }
    }
}