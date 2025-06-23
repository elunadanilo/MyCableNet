using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class ContratoServicioService : IContratoServicioService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public ContratoServicioService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ContratoServicioDto> CreateAsync(ContratoServicioDto dto)
        {
            // 1. Detectar paquete doble
            dto.EsPaqueteDoble = dto.Detalles.Count >= 2;

            // 2. Calcular descuento 10% si hay paquete doble
            if (dto.EsPaqueteDoble)
            {
                var suma = dto.Detalles.Sum(d => d.PrecioMensual);
                dto.DescuentoAplicado = suma * 0.10m;
            }

            // 3. Mapeo y persistencia
            var entidad = _mapper.Map<ContratoServicio>(dto);
            await _uow.ContratosServicios.AddAsync(entidad);

            // 4. Guardar detalles (usamos el mismo contexto)
            foreach (var det in dto.Detalles)
            {
                entidad.ContratoDetalles!.Add(new ContratoDetalle
                {
                    ServicioId = det.ServicioId,
                    PrecioMensual = det.PrecioMensual,
                    ContratoServicioId = entidad.Id
                });
            }

            await _uow.CompleteAsync();
            return _mapper.Map<ContratoServicioDto>(entidad);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.ContratosServicios.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.ContratosServicios.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<ContratoServicioDto>> GetAllAsync()
        {
            var list = await _uow.ContratosServicios.GetAllAsync();
            return _mapper.Map<IEnumerable<ContratoServicioDto>>(list);
        }

        public async Task<ContratoServicioDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.ContratosServicios.GetByIdAsync(id);
            return ent == null
                ? null
                : _mapper.Map<ContratoServicioDto>(ent);
        }

        public async Task UpdateAsync(int id, ContratoServicioDto dto)
        {
            var ent = await _uow.ContratosServicios.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.ContratosServicios.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}