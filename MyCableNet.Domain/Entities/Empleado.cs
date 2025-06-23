namespace MyCableNet.Domain.Entities
{
    public class Empleado
    {
        #region Public Properties

        public DateTime FechaIngreso { get; set; }

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public ICollection<NominaEmpleado>? Nominas { get; set; }

        public string Puesto { get; set; } = null!;

        public decimal SalarioBase { get; set; }

        #endregion Public Properties
    }
}