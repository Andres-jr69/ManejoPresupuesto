﻿namespace ManejoPresupuesto.Models
{
    public class ResultadoObtenerPorSemana
    {
        public int Semana { get; set; }
        public decimal Monto { get; set; }
        public TipoOperacion TipoOperacionId { get; set; }
        public decimal Ingreso { get; set; }
        public decimal Gasto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
