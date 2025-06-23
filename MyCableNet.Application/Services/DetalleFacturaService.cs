using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public DetalleFacturaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<DetalleFacturaDto> CreateAsync(DetalleFacturaDto dto)
        {
            var ent = _mapper.Map<DetalleFactura>(dto);
            await _uow.DetallesFactura.AddAsync(ent);
            await _uow.CompleteAsync();
            return _mapper.Map<DetalleFacturaDto>(ent);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.DetallesFactura.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.DetallesFactura.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<DetalleFacturaDto>> GetAllAsync()
        {
            var list = await _uow.DetallesFactura.GetAllAsync();
            return _mapper.Map<IEnumerable<DetalleFacturaDto>>(list);
        }

        public async Task<DetalleFacturaDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.DetallesFactura.GetByIdAsync(id);
            return ent == null ? null : _mapper.Map<DetalleFacturaDto>(ent);
        }

        public async Task UpdateAsync(int id, DetalleFacturaDto dto)
        {
            var ent = await _uow.DetallesFactura.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.DetallesFactura.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}