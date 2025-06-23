namespace MyCableNet.Domain.Entities
{
    public class Pago
    {
        #region Public Properties

        public Cliente Cliente { get; set; } = null!;

        public int ClienteId { get; set; }

        public Factura Factura { get; set; } = null!;

        public int FacturaId { get; set; }

        public DateTime FechaPago { get; set; }

        public int Id { get; set; }

        public decimal Monto { get; set; }

        #endregion Public Properties
    }
}