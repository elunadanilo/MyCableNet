using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IContratoDetalleRepository
    {
        #region Public Methods

        Task AddAsync(ContratoDetalle entity);

        void Delete(ContratoDetalle entity);

        Task<IEnumerable<ContratoDetalle>> GetAllAsync();

        Task<ContratoDetalle?> GetByIdAsync(int id);

        void Update(ContratoDetalle entity);

        #endregion Public Methods
    }
}