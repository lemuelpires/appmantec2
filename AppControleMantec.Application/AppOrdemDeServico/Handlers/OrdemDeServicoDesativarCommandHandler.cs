using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoDesativarCommandHandler : IRequestHandler<OrdemDeServicoDesativarCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoDesativarCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoDesativarCommand request, CancellationToken cancellationToken)
        {
            // Buscar a ordem de serviço com base no ID recebido
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(request.Id);

            // Se a ordem de serviço não for encontrada, retorna falso
            if (ordemDeServico == null)
                return false;

            // Caso a ordem de serviço seja encontrada, desativa a ordem
            await _ordemDeServicoRepository.DesativarOrdemDeServicoAsync(request.Id);

            // Caso deseje fazer mais ajustes ao desativar (exemplo: setar outros campos), pode ser feito aqui

            return true;
        }
    }
}
