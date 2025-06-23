using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IContratoServicioService
    {
        #region Public Methods

        Task<ContratoServicioDto> CreateAsync(ContratoServicioDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<ContratoServicioDto>> GetAllAsync();

        Task<ContratoServicioDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, ContratoServicioDto dto);

        #endregion Public Methods
    }
}