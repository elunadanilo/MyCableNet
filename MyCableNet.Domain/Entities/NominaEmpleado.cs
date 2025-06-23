namespace MyCableNet.Domain.Entities
{
    public class NominaEmpleado
    {
        #region Public Properties

        public int Año { get; set; }

        public Empleado Empleado { get; set; } = null!;

        public int EmpleadoId { get; set; }

        public int Id { get; set; }

        public decimal IGSS { get; set; }

        public decimal ISR { get; set; }

        public int Mes { get; set; }

        public bool Pagado { get; set; }

        public decimal SueldoBase { get; set; }

        public decimal TotalPagar { get; set; }

        #endregion Public Properties
    }
}