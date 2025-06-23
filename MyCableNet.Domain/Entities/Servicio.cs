namespace MyCableNet.Domain.Entities
{
    public class Servicio
    {
        #region Public Properties

        public int? CantidadCanales { get; set; }

        public ICollection<ContratoDetalle>? ContratoDetalles { get; set; }

        public ICollection<DetalleFactura>? DetallesFactura { get; set; }

        public bool EsActivo { get; set; } = true;

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public int? VelocidadMbps { get; set; }

        #endregion Public Properties
    }
}