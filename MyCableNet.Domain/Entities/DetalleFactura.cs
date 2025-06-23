namespace MyCableNet.Domain.Entities
{
    public class DetalleFactura
    {
        #region Public Properties

        public decimal CostoMensual { get; set; }

        public Factura Factura { get; set; } = null!;

        public int FacturaId { get; set; }

        public int Id { get; set; }

        public Servicio Servicio { get; set; } = null!;

        public int ServicioId { get; set; }

        public string TipoServicio { get; set; } = null!;

        #endregion Public Properties
    }
}