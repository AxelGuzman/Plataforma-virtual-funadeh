//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FUNADEH_PLATAFORMAVIRTUAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbEventos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbEventos()
        {
            this.tbCapacitacion_Beneficiarios = new HashSet<tbCapacitacion_Beneficiarios>();
        }
    
        public int even_Id { get; set; }
        public string even_Descripcion { get; set; }
        public bool even_Estado { get; set; }
        public int even_UsuarioCrea { get; set; }
        public System.DateTime even_FechaCrea { get; set; }
        public Nullable<int> even_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> even_FechaModifica { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCapacitacion_Beneficiarios> tbCapacitacion_Beneficiarios { get; set; }
    }
}
