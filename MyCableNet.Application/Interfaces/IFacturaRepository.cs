using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IFacturaRepository
    {
        #region Public Methods

        Task AddAsync(Factura entity);

        void Delete(Factura entity);

        Task<IEnumerable<Factura>> GetAllAsync();

        Task<Factura?> GetByIdAsync(int id);

        void Update(Factura entity);

        #endregion Public Methods
    }
}