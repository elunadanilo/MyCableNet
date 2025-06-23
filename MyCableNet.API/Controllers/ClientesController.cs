using Microsoft.AspNetCore.Mvc;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;

namespace MyCableNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        #region Private Fields

        private readonly IClienteService _svc;

        #endregion Private Fields

        #region Public Constructors

        public ClientesController(IClienteService svc) => _svc = svc;

        #endregion Public Constructors

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDto dto)
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var dto = await _svc.GetByIdAsync(id);
            return dto == null ? NotFound() : Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _svc.GetAllAsync();
            return Ok(list);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ClienteDto dto)
        {
            await _svc.UpdateAsync(id, dto);
            return NoContent();
        }

        #endregion Public Methods
    }
}