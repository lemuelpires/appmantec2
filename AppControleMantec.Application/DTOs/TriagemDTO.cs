using System;

namespace AppControleMantec.Application.DTOs
{
    public class TriagemDTO
    {
        public string TecnicoID { get; set; } = null!;
        public string DefeitoRelatadoCliente { get; set; } = string.Empty;
        public string DiagnosticoInicial { get; set; } = string.Empty;
        public string EstadoFisico { get; set; } = string.Empty;
        public bool Liga { get; set; }
        public bool TelaFunciona { get; set; }
        public bool Carrega { get; set; }
        public bool AptoParaReparo { get; set; }
        public decimal? ValorEstimado { get; set; }
        public string ObservacoesTecnicas { get; set; } = string.Empty;
        public string ResultadoTriagem { get; set; } = string.Empty;
    }
}