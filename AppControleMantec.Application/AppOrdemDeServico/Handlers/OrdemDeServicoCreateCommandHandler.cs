using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Domain.Entities;
using System.Collections.Generic;

namespace AppControleMantec.Application.AppOrdemDeServico.Handlers
{
    public class OrdemDeServicoCreateCommandHandler : IRequestHandler<OrdemDeServicoCreateCommand, bool>
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoCreateCommandHandler(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository;
        }

        public async Task<bool> Handle(OrdemDeServicoCreateCommand request, CancellationToken cancellationToken)
        {
            var ordemDeServico = new OrdemDeServico
            {
                ClienteID = request.ClienteID,
                FuncionarioID = request.FuncionarioID,
                ProdutoIDs = request.ProdutoIDs,
                ServicoIDs = request.ServicoIDs,
                DataEntrada = request.DataEntrada,
                DataConclusao = request.DataConclusao,
                Status = request.Status,
                Observacoes = request.Observacoes,
                Ativo = true,

                DefeitoRelatado = request.DefeitoRelatado,
                Diagnostico = request.Diagnostico,
                LaudoTecnico = request.LaudoTecnico,
                Marca = request.Marca,
                Modelo = request.Modelo,
                IMEIouSerial = request.IMEIouSerial,
                SenhaAcesso = request.SenhaAcesso,
                EmGarantia = request.EmGarantia,
                DataGarantia = request.DataGarantia,
                ValorMaoDeObra = request.ValorMaoDeObra,
                ValorPecas = request.ValorPecas,
                ValorTotal = request.ValorTotal,
                FormaPagamento = request.FormaPagamento,
                Pago = request.Pago,
                TipoAtendimento = request.TipoAtendimento,
                Prioridade = request.Prioridade,
                NumeroOS = request.NumeroOS,
                AssinaturaClienteBase64 = request.AssinaturaClienteBase64,
                AssinaturaTecnicoBase64 = request.AssinaturaTecnicoBase64,

                PecasUtilizadas = request.PecasUtilizadas
                    .Select(p => new ItemPeca
                    {
                        ProdutoID = p.ProdutoID,
                        Quantidade = p.Quantidade
                    })
                    .ToList()
            };

            await _ordemDeServicoRepository.InsertOrdemDeServicoAsync(ordemDeServico);
            return true;
        }
    }
}
