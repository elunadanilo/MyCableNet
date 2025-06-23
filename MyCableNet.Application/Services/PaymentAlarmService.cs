using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;

namespace MyCableNet.Application.Services
{
    public class PaymentAlarmService : IPaymentAlarmService
    {
        #region Private Fields

        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public PaymentAlarmService(IUnitOfWork uow)
            => _uow = uow;

        #endregion Public Constructors

        #region Public Methods

        public async Task<IEnumerable<ClienteDto>> GetDueTodayAsync()
        {
            var todosClientes = await _uow.Clientes.GetAllAsync();
            var pagos = await _uow.Pagos.GetAllAsync();

            var due = todosClientes.Where(c =>
            {
                var ultimoPago = pagos
                    .Where(p => p.ClienteId == c.Id)
                    .OrderByDescending(p => p.FechaPago)
                    .FirstOrDefault();

                // si no pagó nunca o si el próximo vencimiento es hoy o anterior
                var fechaVenc = (ultimoPago?.FechaPago ?? c.FechaAlta).AddMonths(1);
                return fechaVenc.Date <= DateTime.UtcNow.Date;
            });

            return due.Select(c => new ClienteDto
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Nombre = c.Nombre,
                FechaAlta = c.FechaAlta,
                Direccion = c.Direccion,
                Correo = c.Correo,
                Telefono = c.Telefono,
                Estado = c.Estado
            });
        }

        #endregion Public Methods
    }
}