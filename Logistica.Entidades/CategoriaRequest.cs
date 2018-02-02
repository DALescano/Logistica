using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Logistica.Entidades
{
    [Table("Categoria")]
    public partial class CategoriaRequest
    {
        public System.Guid idCategoria { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdCategoriaSuperior { get; set; }
        public Nullable<bool> esPrincipal { get; set; }
        public string Filtro { get; set; }
        public Nullable<int> Codigo { get; set; }
    }
}
