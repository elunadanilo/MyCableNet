namespace MyCableNet.Application.DTOs
{
    public class EmpleadoDto
    {
        #region Public Properties

        public DateTime FechaIngreso { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Puesto { get; set; } = null!;

        public decimal SalarioBase { get; set; }

        #endregion Public Properties
    }
}