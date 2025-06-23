using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IServicioRepository
    {
        #region Public Methods

        Task AddAsync(Servicio entity);

        void Delete(Servicio entity);

        Task<IEnumerable<Servicio>> GetAllAsync();

        Task<Servicio?> GetByIdAsync(int id);

        void Update(Servicio entity);

        #endregion Public Methods
    }
}