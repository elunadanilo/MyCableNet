using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IDetalleFacturaService
    {
        #region Public Methods

        Task<DetalleFacturaDto> CreateAsync(DetalleFacturaDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<DetalleFacturaDto>> GetAllAsync();

        Task<DetalleFacturaDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, DetalleFacturaDto dto);

        #endregion Public Methods
    }
}