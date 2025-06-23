using Microsoft.AspNetCore.Mvc;
using MyCableNet.Application.DTOs;
using MyCableNet.Application.Interfaces;
using MyCableNet.Application.DTOs;

namespace MyCableNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioService _svc;
        public ServiciosController(IServicioService svc) => _svc = svc;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _svc.GetAllAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id) =>
            (await _svc.GetByIdAsync(id)) is ServicioDto dto
                ? Ok(dto)
                : NotFound();

        [HttpPost]
        public async Task<IActionResult> Create(ServicioDto dto)
        {
            var created = await _svc.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ServicioDto dto)
        {
            await _svc.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _svc.DeleteAsync(id);
            return NoContent();
        }
    }
}
