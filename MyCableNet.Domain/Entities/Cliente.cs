namespace MyCableNet.Domain.Entities
{
    public class Cliente
    {
        #region Public Properties

        public string Codigo { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Estado { get; set; } = "Activo";

        public DateTime FechaAlta { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Factura> Facturas { get; set; } = new List<Factura>();

        #endregion Public Properties
    }
}