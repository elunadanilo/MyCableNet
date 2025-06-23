using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class ContratoDetalleService : IContratoDetalleService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public ContratoDetalleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ContratoDetalleDto> CreateAsync(ContratoDetalleDto dto)
        {
            var ent = _mapper.Map<ContratoDetalle>(dto);
            await _uow.ContratoDetalles.AddAsync(ent);
            await _uow.CompleteAsync();
            return _mapper.Map<ContratoDetalleDto>(ent);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.ContratoDetalles.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.ContratoDetalles.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<ContratoDetalleDto>> GetAllAsync()
        {
            var list = await _uow.ContratoDetalles.GetAllAsync();
            return _mapper.Map<IEnumerable<ContratoDetalleDto>>(list);
        }

        public async Task<ContratoDetalleDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.ContratoDetalles.GetByIdAsync(id);
            return ent == null
                ? null
                : _mapper.Map<ContratoDetalleDto>(ent);
        }

        public async Task UpdateAsync(int id, ContratoDetalleDto dto)
        {
            var ent = await _uow.ContratoDetalles.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.ContratoDetalles.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}