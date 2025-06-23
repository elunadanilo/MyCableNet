using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IClienteRepository
    {
        #region Public Methods

        Task AddAsync(Cliente entity);

        void Delete(Cliente entity);

        Task<IEnumerable<Cliente>> GetAllAsync();

        Task<Cliente?> GetByIdAsync(int id);

        void Update(Cliente entity);

        #endregion Public Methods
    }
}