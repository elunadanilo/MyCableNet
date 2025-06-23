namespace MyCableNet.Application.DTOs
{
    public class PagoDto
    {
        #region Public Properties

        public int ClienteId { get; set; }

        public int FacturaId { get; set; }

        public DateTime FechaPago { get; set; }

        public int Id { get; set; }

        public decimal Monto { get; set; }

        #endregion Public Properties
    }
}