using AutoMapper;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public EmpleadoService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<EmpleadoDto> CreateAsync(EmpleadoDto dto)
        {
            var ent = _mapper.Map<Empleado>(dto);
            await _uow.Empleados.AddAsync(ent);
            await _uow.CompleteAsync();
            return _mapper.Map<EmpleadoDto>(ent);
        }

        public async Task DeleteAsync(int id)
        {
            var ent = await _uow.Empleados.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _uow.Empleados.Delete(ent);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<EmpleadoDto>> GetAllAsync()
        {
            var list = await _uow.Empleados.GetAllAsync();
            return _mapper.Map<IEnumerable<EmpleadoDto>>(list);
        }

        public async Task<EmpleadoDto?> GetByIdAsync(int id)
        {
            var ent = await _uow.Empleados.GetByIdAsync(id);
            return ent == null ? null : _mapper.Map<EmpleadoDto>(ent);
        }

        public async Task UpdateAsync(int id, EmpleadoDto dto)
        {
            var ent = await _uow.Empleados.GetByIdAsync(id)
                      ?? throw new KeyNotFoundException();
            _mapper.Map(dto, ent);
            _uow.Empleados.Update(ent);
            await _uow.CompleteAsync();
        }

        #endregion Public Methods
    }
}