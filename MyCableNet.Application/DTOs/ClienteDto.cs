namespace MyCableNet.Application.DTOs
{
    public class ClienteDto
    {
        #region Public Properties

        public string Codigo { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public DateTime FechaAlta { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        #endregion Public Properties
    }
}