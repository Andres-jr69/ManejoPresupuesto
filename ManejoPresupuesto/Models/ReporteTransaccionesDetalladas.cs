namespace ManejoPresupuesto.Models
{
    public class ReporteTransaccionesDetalladas
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set;}

        public IEnumerable<TransaccionesPorFecha> TransaccionesAgrupadas { get; set; }
        public decimal BalanceDeposito => TransaccionesAgrupadas.Sum(x => x.BalanceDeposito);
        public decimal BalanceRetiro => TransaccionesAgrupadas.Sum(x => x.BalanceRetiro);
        public decimal Total => BalanceDeposito - BalanceRetiro;



        public class TransaccionesPorFecha
        {
            public DateTime FechaTransaccion { get; set; }
            public IEnumerable<Transaccion> Transacciones { get; set; }
            public decimal BalanceDeposito => Transacciones.Where(x =>
            x.TipoOperacionId == TipoOperacion.Ingreso).Sum(x => x.Monto);

            public decimal BalanceRetiro => Transacciones.Where(x =>
           x.TipoOperacionId == TipoOperacion.Gasto).Sum(x => x.Monto);

        }
    }
}
