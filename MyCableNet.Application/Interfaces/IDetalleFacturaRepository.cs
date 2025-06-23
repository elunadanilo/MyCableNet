using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IDetalleFacturaRepository
    {
        #region Public Methods

        Task AddAsync(DetalleFactura entity);

        void Delete(DetalleFactura entity);

        Task<IEnumerable<DetalleFactura>> GetAllAsync();

        Task<DetalleFactura?> GetByIdAsync(int id);

        void Update(DetalleFactura entity);

        #endregion Public Methods
    }
}