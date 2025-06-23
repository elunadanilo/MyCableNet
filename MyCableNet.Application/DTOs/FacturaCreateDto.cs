namespace MyCableNet.Application.DTOs
{
    public class FacturaCreateDto
    {
        #region Public Properties

        public int ClienteId { get; set; }

        public int ContratoId { get; set; }

        /// <summary>
        /// Lista de detalles con servicio, tipo y costo base
        /// </summary>
        public List<DetalleFacturaDto> Detalles { get; set; } = new();

        /// <summary>
        /// Meses que paga por anticipado (para 6×5)
        /// </summary>
        public int MesesAnticipados { get; set; } = 1;

        /// <summary>
        /// Serie que asigna el usuario
        /// </summary>
        public string Serie { get; set; } = null!;

        #endregion Public Properties
    }
}