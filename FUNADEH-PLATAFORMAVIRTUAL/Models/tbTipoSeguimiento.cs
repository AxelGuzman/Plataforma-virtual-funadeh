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
    
    public partial class tbTipoSeguimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipoSeguimiento()
        {
            this.tbSeguimiento = new HashSet<tbSeguimiento>();
        }
    
        public int tpseg_Id { get; set; }
        public string tpseg_Descripcion { get; set; }
        public int tpseg_UsuarioCrea { get; set; }
        public System.DateTime tpseg_FechaCrea { get; set; }
        public Nullable<int> tpseg_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> tpseg_FechaModifica { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbSeguimiento> tbSeguimiento { get; set; }
    }
}