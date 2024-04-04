namespace ManejoPresupuesto.Models
{
    public class TransaccionActualizarViewModel : TransaccioneCreacionViewModel
    {
        public int CuentaAnteriorId { get; set; }
        public decimal MontoAnterior { get; set; }
        public string UrlRetorno { get; set; }
    }
}
