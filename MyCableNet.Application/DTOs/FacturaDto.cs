namespace MyCableNet.Application.DTOs
{
    public class FacturaDto
    {
        #region Public Properties

        public int ClienteId { get; set; }

        public string Estado { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public int Id { get; set; }

        public string Numero { get; set; } = null!;

        public string Serie { get; set; } = null!;

        public decimal Total { get; set; }

        #endregion Public Properties
    }
}