using MyCableNet.Application.DTOs;

namespace MyCableNet.Application.Interfaces
{
    public interface IPaymentAlarmService
    {
        #region Public Methods

        Task<IEnumerable<ClienteDto>> GetDueTodayAsync();

        #endregion Public Methods
    }
}