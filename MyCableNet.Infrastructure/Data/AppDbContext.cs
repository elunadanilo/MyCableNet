using Microsoft.EntityFrameworkCore;
using MyCableNet.Domain.Entities;

namespace MyCableNet.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        #region Public Constructors

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Servicio> Servicios { get; set; } = null!;
        public DbSet<ContratoServicio> ContratosServicios { get; set; } = null!;
        public DbSet<ContratoDetalle> ContratoDetalles { get; set; } = null!;
        public DbSet<Factura> Facturas { get; set; } = null!;
        public DbSet<DetalleFactura> DetallesFactura { get; set; } = null!;
        public DbSet<Pago> Pagos { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<NominaEmpleado> NominasEmpleados { get; set; } = null!;

        #endregion Public Properties

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // Keys
            mb.Entity<Cliente>().HasKey(c => c.Id);
            mb.Entity<Servicio>().HasKey(s => s.Id);
            mb.Entity<ContratoServicio>().HasKey(c => c.Id);
            mb.Entity<ContratoDetalle>().HasKey(cd => cd.Id);
            mb.Entity<Factura>().HasKey(f => f.Id);
            mb.Entity<DetalleFactura>().HasKey(df => df.Id);
            mb.Entity<Pago>().HasKey(p => p.Id);
            mb.Entity<Empleado>().HasKey(e => e.Id);
            mb.Entity<NominaEmpleado>().HasKey(n => n.Id);

            // Decimal precision configuration
            mb.Entity<ContratoDetalle>()
              .Property(cd => cd.PrecioMensual)
              .HasPrecision(18, 2);

            mb.Entity<ContratoServicio>()
              .Property(cs => cs.DescuentoAplicado)
              .HasPrecision(18, 2);

            mb.Entity<DetalleFactura>()
              .Property(df => df.CostoMensual)
              .HasPrecision(18, 2);

            mb.Entity<Factura>()
              .Property(f => f.Total)
              .HasPrecision(18, 2);

            mb.Entity<Pago>()
              .Property(p => p.Monto)
              .HasPrecision(18, 2);

            mb.Entity<Empleado>()
              .Property(e => e.SalarioBase)
              .HasPrecision(18, 2);

            mb.Entity<NominaEmpleado>()
              .Property(n => n.SueldoBase)
              .HasPrecision(18, 2);
            mb.Entity<NominaEmpleado>()
              .Property(n => n.IGSS)
              .HasPrecision(18, 2);
            mb.Entity<NominaEmpleado>()
              .Property(n => n.ISR)
              .HasPrecision(18, 2);
            mb.Entity<NominaEmpleado>()
              .Property(n => n.TotalPagar)
              .HasPrecision(18, 2);

            // Configure relationships to avoid multiple cascade paths
            mb.Entity<Pago>()
              .HasOne(p => p.Factura)
              .WithMany(f => f.Pagos)
              .HasForeignKey(p => p.FacturaId)
              .OnDelete(DeleteBehavior.Restrict);

            mb.Entity<Pago>()
              .HasOne(p => p.Cliente)
              .WithMany(c => c.Pagos)
              .HasForeignKey(p => p.ClienteId)
              .OnDelete(DeleteBehavior.Cascade);

            // Optionally, configure DetalleFactura relationship restrictions if needed
            mb.Entity<DetalleFactura>()
              .HasOne(df => df.Factura)
              .WithMany(f => f.Detalles)
              .HasForeignKey(df => df.FacturaId)
              .OnDelete(DeleteBehavior.Cascade);

            mb.Entity<ContratoDetalle>()
              .HasOne(cd => cd.ContratoServicio)
              .WithMany(c => c.ContratoDetalles)
              .HasForeignKey(cd => cd.ContratoServicioId)
              .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(mb);
        }

        #endregion Protected Methods
    }
}