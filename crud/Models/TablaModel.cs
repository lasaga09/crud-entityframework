using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crud.Models;

namespace crud.Models
{
    public class TablaModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public DateTime fecha { get; set; }
    }
}