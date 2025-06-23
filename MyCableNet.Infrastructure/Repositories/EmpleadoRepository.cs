using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public EmpleadoRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(Empleado entity) =>
            await _ctx.Empleados.AddAsync(entity);

        public void Delete(Empleado entity) =>
            _ctx.Empleados.Remove(entity);

        public async Task<IEnumerable<Empleado>> GetAllAsync() =>
                            await _ctx.Empleados.ToListAsync();

        public async Task<Empleado?> GetByIdAsync(int id) =>
            await _ctx.Empleados.FindAsync(id);

        public void Update(Empleado entity) =>
            _ctx.Empleados.Update(entity);

        #endregion Public Methods
    }
}