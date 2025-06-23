using Microsoft.AspNetCore.Mvc;
using MyCableNet.Application.Interfaces;
using MyCableNet.Application.DTOs;

namespace MyCableNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContratosServiciosController : ControllerBase
    {
        #region Private Fields

        private readonly IContratoServicioService _svc;

        #endregion Private Fields

        #region Public Constructors

        public ContratosServiciosController(IContratoServicioService svc) => _svc = svc;

        #endregion Public Constructors

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Create(ContratoServicioDto dto)
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
        public async Task<IActionResult> Get(int id) =>
            (await _svc.GetByIdAsync(id)) is ContratoServicioDto dto
                ? Ok(dto)
                : NotFound();

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _svc.GetAllAsync());

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ContratoServicioDto dto)
        {
            await _svc.UpdateAsync(id, dto);
            return NoContent();
        }

        #endregion Public Methods
    }
}