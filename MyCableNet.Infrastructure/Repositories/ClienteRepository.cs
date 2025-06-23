using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Domain.Entities;
using MyCableNet.Infrastructure.Data;

namespace MyCableNet.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        #region Private Fields

        private readonly AppDbContext _ctx;

        #endregion Private Fields

        #region Public Constructors

        public ClienteRepository(AppDbContext ctx) => _ctx = ctx;

        #endregion Public Constructors

        #region Public Methods

        public async Task AddAsync(Cliente entity) =>
            await _ctx.Clientes.AddAsync(entity);

        public void Delete(Cliente entity) =>
            _ctx.Clientes.Remove(entity);

        public async Task<IEnumerable<Cliente>> GetAllAsync() =>
                            await _ctx.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id) =>
            await _ctx.Clientes.FindAsync(id);

        public void Update(Cliente entity) =>
            _ctx.Clientes.Update(entity);

        #endregion Public Methods
    }
}