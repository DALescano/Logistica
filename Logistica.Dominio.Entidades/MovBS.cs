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
    
    public partial class MovBS
    {
        public System.Guid idMov { get; set; }
        public Nullable<int> nMovItem { get; set; }
        public System.Guid idBS { get; set; }
        public Nullable<int> nMovBSOrden { get; set; }
    
        public virtual Mov Mov { get; set; }
    }
}