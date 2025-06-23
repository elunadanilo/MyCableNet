using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IContratoDetalleService
    {
        #region Public Methods

        Task<ContratoDetalleDto> CreateAsync(ContratoDetalleDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<ContratoDetalleDto>> GetAllAsync();

        Task<ContratoDetalleDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, ContratoDetalleDto dto);

        #endregion Public Methods
    }
}