using MediatR;
using System.Collections.Generic;

namespace AppControleMantec.Application.Commands
{
    public class CriarOrdemDeServicoCommand : IRequest<string>
    {
        public string ClienteID { get; set; } = null!;
        public string FuncionarioID { get; set; } = null!;
        public List<string> ServicoIDs { get; set; } = new();

        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string IMEIouSerial { get; set; } = string.Empty;

        public string DefeitoRelatado { get; set; } = string.Empty;
        public decimal ValorMaoDeObra { get; set; }
        public string TipoAtendimento { get; set; } = string.Empty;
        public string Prioridade { get; set; } = string.Empty;
    }
}
