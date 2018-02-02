using System.Configuration;
using System.Data.Entity.Infrastructure.Design;
using System.IO;
using Med.Comun.Datos.Core;
using Med.Comun.Datos.ICore;
using System.Linq;
using Logistica.Datos.Interfaces;


namespace Logistica.Datos.Modelo.PEC
{
	public partial class UnitOfWorkPEC : BaseUnitOfWork, IUnitOfWorkPEC
	{
		public UnitOfWorkPEC(IDbContext ctx) : base(ctx, true)
		{ }
	}
}
