using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IFacturaService
    {
        #region Public Methods

        Task<FacturaDto> CreateAsync(FacturaCreateDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<FacturaDto>> GetAllAsync();

        Task<FacturaDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, FacturaDto dto);

        #endregion Public Methods
    }
}