namespace Logistica.Datos.Repositorio
{
    using Med.Comun.Datos.ICore;
    using Med.Comun.Datos.ICore.Repository;
    using Logistica.Dominio.Entidades;
    using Logistica.Dominio.RepositorioInterfaces;
    using System;
    using System.Collections.Generic;
    
    public partial class CategoriaRepository: Repository<Categoria> , ICategoriaRepository
    {
    	public CategoriaRepository(IContext context)
    	    :base(context)
    	{
        }
    }
}
