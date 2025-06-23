using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public FacturaRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(Factura entity) =>
            await _ctx.Facturas.AddAsync(entity);

        public void Delete(Factura entity) =>
            _ctx.Facturas.Remove(entity);

        public async Task<IEnumerable<Factura>> GetAllAsync() =>
                            await _ctx.Facturas.Include(f => f.Detalles).ToListAsync();

        public async Task<Factura?> GetByIdAsync(int id) =>
            await _ctx.Facturas
                      .Include(f => f.Detalles)
                      .FirstOrDefaultAsync(f => f.Id == id);

        public void Update(Factura entity) =>
            _ctx.Facturas.Update(entity);

        #endregion Public Methods
    }
}