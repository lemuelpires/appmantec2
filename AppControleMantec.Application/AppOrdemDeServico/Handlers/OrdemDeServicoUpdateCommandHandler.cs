using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoUpdateCommandHandler : IRequestHandler<OrdemDeServicoUpdateCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoUpdateCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoUpdateCommand request, CancellationToken cancellationToken)
        {
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(request.Id);

            if (ordemDeServico == null)
                return false;

            // Atualiza os campos com os novos dados
            ordemDeServico.ClienteID = request.ClienteID;
            ordemDeServico.FuncionarioID = request.FuncionarioID;
            ordemDeServico.ProdutoIDs = request.ProdutoIDs;
            ordemDeServico.ServicoIDs = request.ServicoIDs;
            ordemDeServico.DataEntrada = request.DataEntrada;
            ordemDeServico.DataConclusao = request.DataConclusao;
            ordemDeServico.Status = request.Status;
            ordemDeServico.Observacoes = request.Observacoes;

            // Campos técnicos
            ordemDeServico.DefeitoRelatado = request.DefeitoRelatado;
            ordemDeServico.Diagnostico = request.Diagnostico;
            ordemDeServico.LaudoTecnico = request.LaudoTecnico;
            ordemDeServico.Marca = request.Marca;
            ordemDeServico.Modelo = request.Modelo;
            ordemDeServico.IMEIouSerial = request.IMEIouSerial;
            ordemDeServico.SenhaAcesso = request.SenhaAcesso;

            // Garantia e pagamento
            ordemDeServico.EmGarantia = request.EmGarantia;
            ordemDeServico.DataGarantia = request.DataGarantia;
            ordemDeServico.ValorMaoDeObra = request.ValorMaoDeObra;
            ordemDeServico.ValorPecas = request.ValorPecas;
            ordemDeServico.ValorTotal = request.ValorTotal;
            ordemDeServico.FormaPagamento = request.FormaPagamento;
            ordemDeServico.Pago = request.Pago;

            // Atendimento
            ordemDeServico.TipoAtendimento = request.TipoAtendimento;
            ordemDeServico.Prioridade = request.Prioridade;
            ordemDeServico.NumeroOS = request.NumeroOS;

            // Assinaturas
            ordemDeServico.AssinaturaClienteBase64 = request.AssinaturaClienteBase64;
            ordemDeServico.AssinaturaTecnicoBase64 = request.AssinaturaTecnicoBase64;

            // Peças utilizadas (mapeamento manual)
            ordemDeServico.PecasUtilizadas = request.PecasUtilizadas
                .Select(p => new ItemPeca
                {
                    ProdutoID = p.ProdutoID,
                    Quantidade = p.Quantidade
                })
                .ToList();

            // Atualiza no repositório
            await _ordemDeServicoRepository.UpdateOrdemDeServicoAsync(ordemDeServico);
            return true;
        }
    }
}
