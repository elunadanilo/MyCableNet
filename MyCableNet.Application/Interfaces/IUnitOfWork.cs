namespace MyCableNet.Application.Interfaces
{
    public interface IUnitOfWork
    {
        #region Public Properties

        IClienteRepository Clientes { get; }
        IServicioRepository Servicios { get; }
        IContratoServicioRepository ContratosServicios { get; }
        IContratoDetalleRepository ContratoDetalles { get; }
        IFacturaRepository Facturas { get; }
        IDetalleFacturaRepository DetallesFactura { get; }
        IPagoRepository Pagos { get; }
        IEmpleadoRepository Empleados { get; }
        INominaEmpleadoRepository NominasEmpleados { get; }

        #endregion Public Properties

        #region Public Methods

        Task<int> CompleteAsync();

        #endregion Public Methods
    }
}