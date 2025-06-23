using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class FacturaService : IFacturaService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public FacturaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<FacturaDto> CreateAsync(FacturaCreateDto dto)
        {
            // 1. Obtener contrato y sus detalles
            var contrato = await _uow.ContratosServicios.GetByIdAsync(dto.ContratoId)
                           ?? throw new KeyNotFoundException("Contrato no encontrado");

            // 2. Generar número y fecha
            var factura = new Factura
            {
                Numero = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(),
                Serie = dto.Serie,
                Fecha = DateTime.UtcNow,
                ClienteId = dto.ClienteId,
                Estado = "Pendiente"
            };

            // 3. Añadir detalles
            foreach (var det in dto.Detalles)
            {
                factura.Detalles!.Add(new DetalleFactura
                {
                    ServicioId = det.ServicioId,
                    TipoServicio = det.TipoServicio,
                    CostoMensual = det.CostoMensual,
                    Factura = factura
                });
            }

            // 4. Calcular total base y aplicar 10% si el contrato es doble
            var totalBase = factura.Detalles.Sum(d => d.CostoMensual);
            if (contrato.EsPaqueteDoble)
                totalBase -= totalBase * 0.10m;

            // 5. Promoción 6×5
            if (dto.MesesAnticipados >= 6)
            {
                // cobrar solo 5 meses
                totalBase = totalBase / dto.MesesAnticipados * 5;
            }

            factura.Total = totalBase;

            // 6. Persistir
            await _uow.Facturas.AddAsync(factura);
            await _uow.CompleteAsync();

            return _mapper.Map<FacturaDto>(factura);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.Facturas.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.Facturas.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<FacturaDto>> GetAllAsync()
        {
            var list = await _uow.Facturas.GetAllAsync();
            return _mapper.Map<IEnumerable<FacturaDto>>(list);
        }

        public async Task<FacturaDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.Facturas.GetByIdAsync(id);
            return ent == null ? null : _mapper.Map<FacturaDto>(ent);
        }

        public async Task UpdateAsync(int id, FacturaDto dto)
        {
            var ent = await _uow.Facturas.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.Facturas.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}