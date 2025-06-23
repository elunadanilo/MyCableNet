using MyCableNet.Application.DTOs;
using MyCableNet.Domain.Entities;
using AutoMapper;

namespace MyCableNet.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        #region Public Constructors

        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Servicio, ServicioDto>().ReverseMap();
            CreateMap<ContratoServicio, ContratoServicioDto>().ReverseMap();
            CreateMap<ContratoDetalle, ContratoDetalleDto>().ReverseMap();
            CreateMap<Factura, FacturaDto>().ReverseMap();
            CreateMap<DetalleFactura, DetalleFacturaDto>().ReverseMap();
            CreateMap<Pago, PagoDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<NominaEmpleado, NominaEmpleadoDto>().ReverseMap();
        }

        #endregion Public Constructors
    }
}