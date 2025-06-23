namespace MyCableNet.Domain.Entities
{
    public class ContratoServicio
    {
        #region Public Properties

        public Cliente Cliente { get; set; } = null!;

        public int ClienteId { get; set; }

        public ICollection<ContratoDetalle> ContratoDetalles { get; set; } = new List<ContratoDetalle>();

        public decimal DescuentoAplicado { get; set; }

        public bool EsPaqueteDoble { get; set; }

        public string Estado { get; set; } = "Activo";

        public DateTime? FechaFin { get; set; }

        public DateTime FechaInicio { get; set; }

        public int Id { get; set; }

        #endregion Public Properties
    }
}