using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class ContratoDetalleRepository : IContratoDetalleRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public ContratoDetalleRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(ContratoDetalle entity) =>
            await _ctx.ContratoDetalles.AddAsync(entity);

        public void Delete(ContratoDetalle entity) =>
            _ctx.ContratoDetalles.Remove(entity);

        public async Task<IEnumerable<ContratoDetalle>> GetAllAsync() =>
                            await _ctx.ContratoDetalles.Include(d => d.Servicio).ToListAsync();

        public async Task<ContratoDetalle?> GetByIdAsync(int id) =>
            await _ctx.ContratoDetalles
                      .Include(d => d.Servicio)
                      .FirstOrDefaultAsync(d => d.Id == id);

        public void Update(ContratoDetalle entity) =>
            _ctx.ContratoDetalles.Update(entity);

        #endregion Public Methods
    }
}