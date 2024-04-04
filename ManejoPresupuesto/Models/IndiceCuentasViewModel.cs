namespace ManejoPresupuesto.Models
{
    public class IndiceCuentasViewModel
    {
        public string TipoCuenta { get; set; }
        public IEnumerable<Cuenta> Cuentas { get; set; }
        //Mostrar sumatoria de los balances
        public decimal Balance => Cuentas.Sum(x => x.Balance);
    }
}
