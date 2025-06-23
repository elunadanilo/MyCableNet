using MyCableNet.Application.Interfaces;

namespace MyCableNet.API
{
    public class SpeedIncreaseHostedService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<SpeedIncreaseHostedService> _logger;

        public SpeedIncreaseHostedService(
            IServiceScopeFactory scopeFactory,
            ILogger<SpeedIncreaseHostedService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SpeedIncreaseHostedService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                    var clientes = await uow.Clientes.GetAllAsync();
                    foreach (var c in clientes)
                    {
                        var contrato = (await uow.ContratosServicios.GetAllAsync())
                            .FirstOrDefault(x => x.ClienteId == c.Id && x.Estado == "Activo");
                        if (contrato == null) continue;

                        var detalles = contrato.ContratoDetalles
                                                .Where(d => d.Servicio.Tipo.Contains("Internet"))
                                                .ToList();
                        foreach (var det in detalles)
                        {
                            var svc = await uow.Servicios.GetByIdAsync(det.ServicioId);
                            if (svc?.VelocidadMbps is int vel && vel < 50)
                            {
                                svc.VelocidadMbps = Math.Min(50, vel + 5);
                                uow.Servicios.Update(svc);
                            }
                        }
                    }

                    await uow.CompleteAsync();
                    _logger.LogInformation("SpeedIncreaseHostedService ran at {time}", DateTimeOffset.Now);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in SpeedIncreaseHostedService");
                }

                // Esperar 30 días antes de la siguiente ejecución
                //await Task.Delay(TimeSpan.FromDays(30), stoppingToken);
                //para pruebas lo habilitamos a cada 10 segundos
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

            _logger.LogInformation("SpeedIncreaseHostedService stopping.");
        }
    }
}
