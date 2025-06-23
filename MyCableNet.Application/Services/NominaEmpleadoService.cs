using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class NominaEmpleadoService : INominaEmpleadoService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public NominaEmpleadoService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<NominaEmpleadoDto> CreateAsync(NominaEmpleadoDto dto)
        {
            // 1. Mapeo
            var nomina = _mapper.Map<NominaEmpleado>(dto);

            // 2. Calcular IGSS (4.83% del sueldo base) y ISR (5% de sueldo base)
            nomina.IGSS = nomina.SueldoBase * 0.0483m;
            nomina.ISR = nomina.SueldoBase * 0.05m;
            nomina.TotalPagar = nomina.SueldoBase - nomina.IGSS - nomina.ISR;

            // 3. Persistir
            await _uow.NominasEmpleados.AddAsync(nomina);
            await _uow.CompleteAsync();

            return _mapper.Map<NominaEmpleadoDto>(nomina);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.NominasEmpleados.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.NominasEmpleados.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<NominaEmpleadoDto>> GetAllAsync()
        {
            var list = await _uow.NominasEmpleados.GetAllAsync();
            return _mapper.Map<IEnumerable<NominaEmpleadoDto>>(list);
        }

        public async Task<NominaEmpleadoDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.NominasEmpleados.GetByIdAsync(id);
            return ent == null ? null : _mapper.Map<NominaEmpleadoDto>(ent);
        }

        public async Task UpdateAsync(int id, NominaEmpleadoDto dto)
        {
            var ent = await _uow.NominasEmpleados.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.NominasEmpleados.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}