using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IPagoRepository
    {
        #region Public Methods

        Task AddAsync(Pago entity);

        void Delete(Pago entity);

        Task<IEnumerable<Pago>> GetAllAsync();

        Task<Pago?> GetByIdAsync(int id);

        void Update(Pago entity);

        #endregion Public Methods
    }
}