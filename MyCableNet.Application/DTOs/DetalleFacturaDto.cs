namespace MyCableNet.Application.DTOs
{
    public class DetalleFacturaDto
    {
        #region Public Properties

        public decimal CostoMensual { get; set; }

        public int FacturaId { get; set; }

        public int Id { get; set; }

        public int ServicioId { get; set; }

        public string TipoServicio { get; set; } = null!;

        #endregion Public Properties
    }
}