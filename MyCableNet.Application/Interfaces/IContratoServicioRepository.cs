using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IContratoServicioRepository
    {
        #region Public Methods

        Task AddAsync(ContratoServicio entity);

        void Delete(ContratoServicio entity);

        Task<IEnumerable<ContratoServicio>> GetAllAsync();

        Task<ContratoServicio?> GetByIdAsync(int id);

        void Update(ContratoServicio entity);

        #endregion Public Methods
    }
}