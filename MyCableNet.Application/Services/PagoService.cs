using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class PagoService : IPagoService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public PagoService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<PagoDto> CreateAsync(PagoDto dto)
        {
            // 1. Mapeo
            var pago = _mapper.Map<Pago>(dto);

            // 2. Contar pagos de los últimos 6 meses
            var pagosPrevios = await _uow.Pagos.GetAllAsync();
            var pagosRecientes = pagosPrevios
            .Where(p => p.ClienteId == pago.ClienteId &&
                        p.FechaPago > DateTime.UtcNow.AddMonths(-6))
            .Count();

            // 3. Promoción 6×5
            if (pagosRecientes == 5)
            {
                pago.Monto = 0m; // sexto gratis
            }

            // 4. Persistir pago
            await _uow.Pagos.AddAsync(pago);
            await _uow.CompleteAsync();

            // 5. Chequear morosidad: facturas sin pago en los últimos 2 meses
            // Traemos todas las facturas y pagos a memoria
            var facturas = await _uow.Facturas.GetAllAsync();
            var pagos = await _uow.Pagos.GetAllAsync();

            // Filtramos las facturas del cliente sin pago en los últimos 2 meses
            var sinPagar2meses = facturas
                .Where(f => f.ClienteId == pago.ClienteId
                            && !pagos.Any(p => p.FacturaId == f.Id)
                            && f.Fecha <= DateTime.UtcNow.AddMonths(-2))
                .Count();

            if (sinPagar2meses >= 2)
            {
                // suspender servicios: actualizar contrato
                var contrato = (await _uow.ContratosServicios
                    .GetAllAsync())
                    .FirstOrDefault(c => c.ClienteId == pago.ClienteId && c.Estado == "Activo");

                if (contrato != null)
                {
                    contrato.Estado = "Suspendido";
                    _uow.ContratosServicios.Update(contrato);
                    await _uow.CompleteAsync();
                }
            }

            return _mapper.Map<PagoDto>(pago);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.Pagos.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.Pagos.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<PagoDto>> GetAllAsync()
        {
            var list = await _uow.Pagos.GetAllAsync();
            return _mapper.Map<IEnumerable<PagoDto>>(list);
        }

        public async Task<PagoDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.Pagos.GetByIdAsync(id);
            return ent == null ? null : _mapper.Map<PagoDto>(ent);
        }

        public async Task UpdateAsync(int id, PagoDto dto)
        {
            var ent = await _uow.Pagos.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.Pagos.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}