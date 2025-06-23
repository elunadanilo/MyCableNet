using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface INominaEmpleadoRepository
    {
        #region Public Methods

        Task AddAsync(NominaEmpleado entity);

        void Delete(NominaEmpleado entity);

        Task<IEnumerable<NominaEmpleado>> GetAllAsync();

        Task<NominaEmpleado?> GetByIdAsync(int id);

        void Update(NominaEmpleado entity);

        #endregion Public Methods
    }
}