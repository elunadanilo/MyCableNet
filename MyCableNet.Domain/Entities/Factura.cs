namespace MyCableNet.Domain.Entities
{
    public class Factura
    {
        #region Public Properties

        public Cliente Cliente { get; set; } = null!;

        public int ClienteId { get; set; }

        public ICollection<DetalleFactura> Detalles { get; set; }
            = new List<DetalleFactura>();

        public string Estado { get; set; } = null!;

        public DateTime Fecha { get; set; }

        public int Id { get; set; }

        public string Numero { get; set; } = null!;

        public ICollection<Pago>? Pagos { get; set; }

        public string Serie { get; set; } = null!;

        public decimal Total { get; set; }

        #endregion Public Properties
    }
}