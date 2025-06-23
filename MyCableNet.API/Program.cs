
using Microsoft.EntityFrameworkCore;
using MyCableNet.Application.Interfaces;
using MyCableNet.Application.Mapping;
using MyCableNet.Application.Services;
using MyCableNet.Infrastructure.Data;
using MyCableNet.Infrastructure.UnitOfWork;

namespace MyCableNet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Configurar DbContext con SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 2. Configurar AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // 3. Registrar UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 4. Registrar todos los servicios de aplicación
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IServicioService, ServicioService>();
            builder.Services.AddScoped<IContratoServicioService, ContratoServicioService>();
            builder.Services.AddScoped<IContratoDetalleService, ContratoDetalleService>();
            builder.Services.AddScoped<IFacturaService, FacturaService>();
            builder.Services.AddScoped<IDetalleFacturaService, DetalleFacturaService>();
            builder.Services.AddScoped<IPagoService, PagoService>();
            builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
            builder.Services.AddScoped<INominaEmpleadoService, NominaEmpleadoService>();
            builder.Services.AddScoped<IPaymentAlarmService, PaymentAlarmService>();

            // 5. Registrar Hosted Service para aumento automático de velocidad
            builder.Services.AddHostedService<SpeedIncreaseHostedService>();

            // 6. Añadir controladores y Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 7. Middleware y pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyCableNet.API v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
