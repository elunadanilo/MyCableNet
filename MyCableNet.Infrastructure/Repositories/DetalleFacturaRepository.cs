using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class DetalleFacturaRepository : IDetalleFacturaRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public DetalleFacturaRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(DetalleFactura entity) =>
            await _ctx.DetallesFactura.AddAsync(entity);

        public void Delete(DetalleFactura entity) =>
            _ctx.DetallesFactura.Remove(entity);

        public async Task<IEnumerable<DetalleFactura>> GetAllAsync() =>
                            await _ctx.DetallesFactura.Include(d => d.Servicio).ToListAsync();

        public async Task<DetalleFactura?> GetByIdAsync(int id) =>
            await _ctx.DetallesFactura
                      .Include(d => d.Servicio)
                      .FirstOrDefaultAsync(d => d.Id == id);

        public void Update(DetalleFactura entity) =>
            _ctx.DetallesFactura.Update(entity);

        #endregion Public Methods
    }
}