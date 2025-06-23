using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IEmpleadoService
    {
        #region Public Methods

        Task<EmpleadoDto> CreateAsync(EmpleadoDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<EmpleadoDto>> GetAllAsync();

        Task<EmpleadoDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, EmpleadoDto dto);

        #endregion Public Methods
    }
}