using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Interfaces
{
    public interface IEmpleadoRepository
    {
        #region Public Methods

        Task AddAsync(Empleado entity);

        void Delete(Empleado entity);

        Task<IEnumerable<Empleado>> GetAllAsync();

        Task<Empleado?> GetByIdAsync(int id);

        void Update(Empleado entity);

        #endregion Public Methods
    }
}