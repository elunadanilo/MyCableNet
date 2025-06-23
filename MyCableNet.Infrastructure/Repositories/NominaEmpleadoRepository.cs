using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class NominaEmpleadoRepository : INominaEmpleadoRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public NominaEmpleadoRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(NominaEmpleado entity) =>
            await _ctx.NominasEmpleados.AddAsync(entity);

        public void Delete(NominaEmpleado entity) =>
            _ctx.NominasEmpleados.Remove(entity);

        public async Task<IEnumerable<NominaEmpleado>> GetAllAsync() =>
                            await _ctx.NominasEmpleados
                      .Include(n => n.Empleado)
                      .ToListAsync();

        public async Task<NominaEmpleado?> GetByIdAsync(int id) =>
            await _ctx.NominasEmpleados
                      .Include(n => n.Empleado)
                      .FirstOrDefaultAsync(n => n.Id == id);

        public void Update(NominaEmpleado entity) =>
            _ctx.NominasEmpleados.Update(entity);

        #endregion Public Methods
    }
}