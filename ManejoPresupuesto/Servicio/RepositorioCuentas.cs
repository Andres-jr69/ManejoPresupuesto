using Dapper;
using ManejoPresupuesto.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuesto.Servicio
{
    public interface IRepositorioCuentas
    {
        Task Actualizar(CuentaCreacionViewModel cuenta);
        Task<IEnumerable<Cuenta>> Buscar(int usuarioId);
        Task Crear(Cuenta cuenta);
        Task Eliminar(int id);
        Task<Cuenta> ObtenerPorId(int id, int usuarioId);
    }

    public class RepositorioCuentas : IRepositorioCuentas
    {
        private readonly string connectionString;
        public RepositorioCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Cuenta cuenta)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>(@"insert into Cuentas (Nombre , TipoCuentaId, Balance, Descripcion)
                                                    values (@Nombre, @TipoCuentaId, @Balance, @Descripcion)
                                                    select SCOPE_IDENTITY();", cuenta);
            cuenta.Id = id;
        }

        public async Task<IEnumerable<Cuenta>> Buscar(int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<Cuenta>(@"SELECT Cuentas.Id, Cuentas.Nombre, Balance, tc.Nombre AS TipoCuenta
                                                    from Cuentas 
                                                    INNER JOIN TiposCuentas tc
                                                    ON tc.Id  = Cuentas.TipoCuentaId
                                                    WHERE tc.UsuarioId = @UsuarioId
                                                    ORDER BY tc.Orden", new {usuarioId}); 
        }

        public async Task<Cuenta> ObtenerPorId(int id, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<Cuenta>(@"SELECT Cuentas.Id, Cuentas.Nombre, Descripcion,
                                                    Balance, TipoCuentaId
                                                    from Cuentas 
                                                    INNER JOIN TiposCuentas tc
                                                    ON tc.Id  = Cuentas.TipoCuentaId
                                                    WHERE tc.UsuarioId = @UsuarioId AND Cuentas.Id = @Id", new {id, usuarioId});
        }

        public async Task Actualizar(CuentaCreacionViewModel cuenta)
        {
            using var connection = new SqlConnection(connectionString);
             await connection.ExecuteAsync(@"update Cuentas
                                                set Nombre = @Nombre, Balance = @Balance, Descripcion = @Descripcion,
                                                TipoCuentaId = @TipoCuentaId
                                                where Id = @Id", cuenta);
        }
        public async Task Eliminar(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(@"DELETe Cuentas WHERE Id = @Id", new { id });
        }
    }
}
