using MyCableNet.Application.Interfaces;
using MyCableNet.Infrastructure.Data;
using MyCableNet.Infrastructure.Repositories;

namespace MyCableNet.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public UnitOfWork(AppDbContext ctx)
        {
            _ctx = ctx;
            Clientes = new ClienteRepository(_ctx);
            Servicios = new ServicioRepository(_ctx);
            ContratosServicios = new ContratoServicioRepository(_ctx);
            ContratoDetalles = new ContratoDetalleRepository(_ctx);
            Facturas = new FacturaRepository(_ctx);
            DetallesFactura = new DetalleFacturaRepository(_ctx);
            Pagos = new PagoRepository(_ctx);
            Empleados = new EmpleadoRepository(_ctx);
            NominasEmpleados = new NominaEmpleadoRepository(_ctx);
        }

        #endregion Public Constructors

        #region Public Properties

        public IClienteRepository Clientes { get; }
        public IServicioRepository Servicios { get; }
        public IContratoServicioRepository ContratosServicios { get; }
        public IContratoDetalleRepository ContratoDetalles { get; }
        public IFacturaRepository Facturas { get; }
        public IDetalleFacturaRepository DetallesFactura { get; }
        public IPagoRepository Pagos { get; }
        public IEmpleadoRepository Empleados { get; }
        public INominaEmpleadoRepository NominasEmpleados { get; }

        #endregion Public Properties

        #region Public Methods

        public async Task<int> CompleteAsync() =>
            await _ctx.SaveChangesAsync();

        #endregion Public Methods
    }
}