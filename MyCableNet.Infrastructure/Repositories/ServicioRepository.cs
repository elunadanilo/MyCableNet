using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public ServicioRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(Servicio entity) =>
            await _ctx.Servicios.AddAsync(entity);

        public void Delete(Servicio entity) =>
            _ctx.Servicios.Remove(entity);

        public async Task<IEnumerable<Servicio>> GetAllAsync() =>
                            await _ctx.Servicios.ToListAsync();

        public async Task<Servicio?> GetByIdAsync(int id) =>
            await _ctx.Servicios.FindAsync(id);

        public void Update(Servicio entity) =>
            _ctx.Servicios.Update(entity);

        #endregion Public Methods
    }
}