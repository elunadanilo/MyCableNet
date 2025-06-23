using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public PagoRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(Pago entity) =>
            await _ctx.Pagos.AddAsync(entity);

        public void Delete(Pago entity) =>
            _ctx.Pagos.Remove(entity);

        public async Task<IEnumerable<Pago>> GetAllAsync() =>
                            await _ctx.Pagos.Include(p => p.Factura).ToListAsync();

        public async Task<Pago?> GetByIdAsync(int id) =>
            await _ctx.Pagos
                      .Include(p => p.Factura)
                      .FirstOrDefaultAsync(p => p.Id == id);

        public void Update(Pago entity) =>
            _ctx.Pagos.Update(entity);

        #endregion Public Methods
    }
}