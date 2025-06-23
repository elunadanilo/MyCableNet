namespace MyCableNet.Domain.Entities
{
    public class ContratoDetalle
    {
        #region Public Properties

        public int Id { get; set; }

        // ← Renombrado
        public int ContratoServicioId { get; set; }
        public ContratoServicio ContratoServicio { get; set; } = null!;

        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;
        public decimal PrecioMensual { get; set; }

        #endregion Public Properties
    }
}