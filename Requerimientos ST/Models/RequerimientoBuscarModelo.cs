using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Requerimientos_ST.Models
{
    public class RequerimientoBuscarModelo
    {
        [Required]
        [Display(Name = "Identificación")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Area")]
        public string Area { get; set; }

        [Required]
        [Display(Name = "Aplicativo")]
        public string Aplicativo { get; set; }

        [Required]
        [Display(Name = "Alcance")]
        public string alcance { get; set; }

        [Required]
        [Display(Name = "Prioridad")]
        public string Prioridad { get; set; }

        [Required]
        [Display(Name = "Desarrollador")]
        public string Desarrollador { get; set; }


        [Display(Name = "Fecha solicitud")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaSolicitud { get; set; }


        [Display(Name = "Fecha desarrollo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaDesarrollo { get; set; }


        [Display(Name = "Fecha prueba")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPrueba { get; set; }
    }
}