using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IServicioService
    {
        #region Public Methods

        Task<ServicioDto> CreateAsync(ServicioDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<ServicioDto>> GetAllAsync();

        Task<ServicioDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, ServicioDto dto);

        #endregion Public Methods
    }
}