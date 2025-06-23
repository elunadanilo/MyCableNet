using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface INominaEmpleadoService
    {
        #region Public Methods

        Task<NominaEmpleadoDto> CreateAsync(NominaEmpleadoDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<NominaEmpleadoDto>> GetAllAsync();

        Task<NominaEmpleadoDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, NominaEmpleadoDto dto);

        #endregion Public Methods
    }
}