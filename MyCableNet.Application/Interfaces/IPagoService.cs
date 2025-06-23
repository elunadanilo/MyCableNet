using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IPagoService
    {
        #region Public Methods

        Task<PagoDto> CreateAsync(PagoDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<PagoDto>> GetAllAsync();

        Task<PagoDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, PagoDto dto);

        #endregion Public Methods
    }
}