using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class ServicioService : IServicioService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public ServicioService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ServicioDto> CreateAsync(ServicioDto dto)
        {
            var ent = _mapper.Map<Servicio>(dto);
            await _uow.Servicios.AddAsync(ent);
            await _uow.CompleteAsync();
            return _mapper.Map<ServicioDto>(ent);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.Servicios.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException();
            _uow.Servicios.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<ServicioDto>> GetAllAsync()
        {
            var list = await _uow.Servicios.GetAllAsync();
            return _mapper.Map<IEnumerable<ServicioDto>>(list);
        }

        public async Task<ServicioDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.Servicios.GetByIdAsync(id);
            return ent is null ? null : _mapper.Map<ServicioDto>(ent);
        }

        public async Task UpdateAsync(int id, ServicioDto dto)
        {
            var ent = await _uow.Servicios.GetByIdAsync(id)
                    ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.Servicios.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}