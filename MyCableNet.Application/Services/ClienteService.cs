using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using AutoMapper;

namespace MyCableNet.Application.Services
{
    public class ClienteService : IClienteService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public ClienteService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ClienteDto> CreateAsync(ClienteDto dto)
        {
            var entity = _mapper.Map<Cliente>(dto);
            await _uow.Clientes.AddAsync(entity);
            await _uow.CompleteAsync();
            return _mapper.Map<ClienteDto>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.Clientes.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException();
            _uow.Clientes.Delete(entity);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var list = await _uow.Clientes.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(list);
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            var entity = await _uow.Clientes.GetByIdAsync(id);
            return entity == null
                ? null
                : _mapper.Map<ClienteDto>(entity);
        }

        public async Task UpdateAsync(int id, ClienteDto dto)
        {
            var entity = await _uow.Clientes.GetByIdAsync(id)
                         ?? throw new KeyNotFoundException();
            _mapper.Map(dto, entity);
            _uow.Clientes.Update(entity);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}