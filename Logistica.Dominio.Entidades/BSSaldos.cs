//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logistica.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class BSSaldos
    {
        public System.Guid idBS { get; set; }
        public int nStock { get; set; }
        public Nullable<int> nMonto { get; set; }
        public Nullable<System.DateTime> dSaldo { get; set; }
        public Nullable<int> nAlmCod { get; set; }
        public Nullable<int> nAlmTpo { get; set; }
    
        public virtual BienesServicios BienesServicios { get; set; }
    }
}
