using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class ContratoServicioRepository : IContratoServicioRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public ContratoServicioRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(ContratoServicio entity) =>
            await _ctx.ContratosServicios.AddAsync(entity);

        public void Delete(ContratoServicio entity) =>
            _ctx.ContratosServicios.Remove(entity);

        public async Task<IEnumerable<ContratoServicio>> GetAllAsync()
        {
            return await _ctx.ContratosServicios
                .Include(c => c.ContratoDetalles)
                    .ThenInclude(d => d.Servicio)
                .Where(c => c.Estado == "Activo")
                .ToListAsync();
        }


        public async Task<ContratoServicio?> GetByIdAsync(int id) =>
            await _ctx.ContratosServicios
                      .Include(c => c.ContratoDetalles)
                      .FirstOrDefaultAsync(c => c.Id == id);

        public void Update(ContratoServicio entity) =>
            _ctx.ContratosServicios.Update(entity);

        #endregion Public Methods
    }
}