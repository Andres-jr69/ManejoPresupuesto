﻿using System.Security.Claims;

namespace ManejoPresupuesto.Servicio
{
    public interface IServicioUsuario
    {
        int ObtenerUsuarioId();
    }
    public class ServicioUsuarios : IServicioUsuario
    {
        private readonly HttpContext httpContext;
        public ServicioUsuarios(IHttpContextAccessor httpContextAccessor)
        {
            httpContext = httpContextAccessor.HttpContext;
        }
        public int ObtenerUsuarioId()
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {
                var idClaim = httpContext.User
                    .Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
                var id = int.Parse(idClaim.Value);
                return id;
            }
            else
            {
                throw new ApplicationException("El usuario no esta autenticado");
            }
           
            
        }
    }
}
