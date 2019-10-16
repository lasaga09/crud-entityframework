using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using crud.Models;

namespace crud.Models
{
    public class TablaViewModel
    {
        public int id { get; set; }

        [Required]
        [StringLength(15)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(49)]
        [Display(Name = "Correo Electronico")]
        public string correo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime fecha { get; set; }
    }
}