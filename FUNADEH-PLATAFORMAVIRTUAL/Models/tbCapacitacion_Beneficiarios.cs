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
    
    public partial class tbCapacitacion_Beneficiarios
    {
        public int capben_Id { get; set; }
        public Nullable<int> cap_Id { get; set; }
        public Nullable<int> tptal_Id { get; set; }
        public Nullable<int> even_Id { get; set; }
        public Nullable<int> ben_Id { get; set; }
    
        public virtual tbTipoTaller tbTipoTaller { get; set; }
        public virtual tbBeneficiarios tbBeneficiarios { get; set; }
        public virtual tbCapacitacion tbCapacitacion { get; set; }
        public virtual tbEventos tbEventos { get; set; }
    }
}