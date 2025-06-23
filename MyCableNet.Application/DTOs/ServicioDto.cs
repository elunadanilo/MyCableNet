namespace MyCableNet.Application.DTOs
{
    public class ServicioDto
    {
        #region Public Properties

        public int? CantidadCanales { get; set; }

        public bool EsActivo { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public int? VelocidadMbps { get; set; }

        #endregion Public Properties
    }
}