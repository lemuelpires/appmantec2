using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoAtivarCommandHandler : IRequestHandler<OrdemDeServicoAtivarCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoAtivarCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoAtivarCommand request, CancellationToken cancellationToken)
        {
            // Buscar a ordem de serviço no repositório usando o ID fornecido
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(request.Id);

            // Se a ordem de serviço não for encontrada, retorna falso
            if (ordemDeServico == null)
                return false;

            // Ativar a ordem de serviço
            await _ordemDeServicoRepository.AtivarOrdemDeServicoAsync(request.Id);

            // Caso seja necessário, adicione a lógica adicional para alterar outros campos, como Status, ou atualizar outros atributos
            // Se desejar realizar ações extras, como atualizar outros atributos ou adicionar validações adicionais, faça-as aqui

            return true;
        }
    }
}
