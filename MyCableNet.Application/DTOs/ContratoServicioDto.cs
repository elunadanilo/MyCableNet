namespace MyCableNet.Application.DTOs
{
    public class ContratoServicioDto
    {
        #region Public Properties

        public int ClienteId { get; set; }

        public decimal DescuentoAplicado { get; set; }

        /// <summary>
        /// Lista de detalles (cada servicio contratado y su precio mensual)
        /// </summary>
        public List<ContratoDetalleDto> Detalles { get; set; } = new();

        // Estos campos se calcularán en el service:
        public bool EsPaqueteDoble { get; set; }

        public DateTime? FechaFin { get; set; }

        public DateTime FechaInicio { get; set; }

        public int Id { get; set; }

        #endregion Public Properties
    }
}