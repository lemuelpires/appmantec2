using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoDesativarCommand : IRequest<bool>
    {
        public string? Id { get; set; }

        // Caso precise de mais propriedades futuramente, você pode adicionar aqui
        // Exemplo:
        // public bool Ativo { get; set; } // Para desativar a ordem de serviço com base em outro estado.
    }
}
