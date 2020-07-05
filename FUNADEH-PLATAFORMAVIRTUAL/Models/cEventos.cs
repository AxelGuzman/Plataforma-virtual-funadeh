using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FUNADEH_PLATAFORMAVIRTUAL.Models
{
    [MetadataType(typeof(cEventos))]
    public partial class tbEventos
    {

    }
    public class cEventos
    {
        public int even_Id { get; set; }
        public string even_Descripcion { get; set; }
        public bool even_Estado { get; set; }
        public int even_UsuarioCrea { get; set; }
        public System.DateTime even_FechaCrea { get; set; }
        public Nullable<int> even_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> even_FechaModifica { get; set; }
    }
}