using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IClienteService
    {
        #region Public Methods

        Task<ClienteDto> CreateAsync(ClienteDto dto);

        Task DeleteAsync(int id);

        Task<IEnumerable<ClienteDto>> GetAllAsync();

        Task<ClienteDto?> GetByIdAsync(int id);

        Task UpdateAsync(int id, ClienteDto dto);

        #endregion Public Methods
    }
}