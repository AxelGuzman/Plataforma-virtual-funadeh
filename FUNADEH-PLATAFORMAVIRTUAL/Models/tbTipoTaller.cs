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
    
    public partial class tbTipoTaller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbTipoTaller()
        {
            this.tbCapacitacion_Beneficiarios = new HashSet<tbCapacitacion_Beneficiarios>();
            this.tbCapacitacion = new HashSet<tbCapacitacion>();
        }
    
        public int tptal_Id { get; set; }
        public int prog_Id { get; set; }
        public string tptal_Titulo { get; set; }
        public string tptal_Descripcion { get; set; }
        public string tptal_Video { get; set; }
        public string tptal_MaterialDidactico1 { get; set; }
        public string tptal_MaterialDidactico2 { get; set; }
        public Nullable<int> even_Id { get; set; }
        public Nullable<int> evac_Id { get; set; }
        public bool tptal_Es_Activo { get; set; }
        public Nullable<bool> tptal_EstadoEnLinea { get; set; }
        public int tptal_UsuarioCrea { get; set; }
        public System.DateTime tptal_FechaCrea { get; set; }
        public Nullable<int> tptal_UsuarioModifica { get; set; }
        public Nullable<System.DateTime> tptal_FechaModifica { get; set; }
    
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        public virtual tbPrograma tbPrograma { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCapacitacion_Beneficiarios> tbCapacitacion_Beneficiarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbCapacitacion> tbCapacitacion { get; set; }
    }
}
