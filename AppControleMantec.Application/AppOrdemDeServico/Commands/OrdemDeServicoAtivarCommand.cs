using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoAtivarCommand : IRequest<bool>
    {
        public string? Id { get; set; }

        // Caso seja necessário, você pode adicionar outras propriedades aqui para fornecer mais contexto
        // Exemplo:
        // public bool Ativo { get; set; } // Se você precisar ativar a ordem de serviço com base em um status.
    }
}
