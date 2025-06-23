using Microsoft.AspNetCore.Mvc;
using MyCableNet.Application.Interfaces;

namespace MyCableNet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlarmasController : ControllerBase
    {
        #region Private Fields

        private readonly IPaymentAlarmService _svc;

        #endregion Private Fields

        #region Public Constructors

        public AlarmasController(IPaymentAlarmService svc) => _svc = svc;

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("vencen-hoy")]
        public async Task<IActionResult> GetDueToday()
        {
            var lista = await _svc.GetDueTodayAsync();
            return Ok(lista);
        }

        #endregion Public Methods
    }
}