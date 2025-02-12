﻿using AutoMapper;
using ManejoPresupuesto.Models;

namespace ManejoPresupuesto.Servicio
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cuenta, CuentaCreacionViewModel>();
            CreateMap<TransaccionActualizarViewModel, Transaccion>().ReverseMap();
        }
    }
}
