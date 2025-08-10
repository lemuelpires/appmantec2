using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Bson;

namespace AppControleMantec.Application.Services
{
    public class OrdemDeServicoAppService : IOrdemDeServicoAppService
    {
        private readonly IOrdemDeServicoRepository _ordemDeServicoRepository;

        public OrdemDeServicoAppService(IOrdemDeServicoRepository ordemDeServicoRepository)
        {
            _ordemDeServicoRepository = ordemDeServicoRepository ?? throw new ArgumentNullException(nameof(ordemDeServicoRepository));
        }

        public async Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAsync()
        {
            var ordensDeServico = await _ordemDeServicoRepository.GetOrdensDeServicoAsync();
            var ordensDeServicoDto = new List<OrdemDeServicoDTO>();

            foreach (var os in ordensDeServico)
            {
                ordensDeServicoDto.Add(new OrdemDeServicoDTO
                {
                    Id = os.Id,
                    ClienteID = os.ClienteID,
                    FuncionarioID = os.FuncionarioID,
                    ProdutoIDs = os.ProdutoIDs,
                    ServicoIDs = os.ServicoIDs,
                    DataEntrada = os.DataEntrada,
                    DataConclusao = os.DataConclusao,
                    Status = os.Status,
                    Observacoes = os.Observacoes,
                    Ativo = os.Ativo,
                    DefeitoRelatado = os.DefeitoRelatado,
                    Diagnostico = os.Diagnostico,
                    LaudoTecnico = os.LaudoTecnico,
                    Marca = os.Marca,
                    Modelo = os.Modelo,
                    IMEIouSerial = os.IMEIouSerial,
                    SenhaAcesso = os.SenhaAcesso,
                    EmGarantia = os.EmGarantia,
                    DataGarantia = os.DataGarantia,
                    ValorMaoDeObra = os.ValorMaoDeObra,
                    ValorPecas = os.ValorPecas,
                    ValorTotal = os.ValorTotal,
                    FormaPagamento = os.FormaPagamento,
                    Pago = os.Pago,
                    TipoAtendimento = os.TipoAtendimento,
                    Prioridade = os.Prioridade,
                    NumeroOS = os.NumeroOS,
                    AssinaturaClienteBase64 = os.AssinaturaClienteBase64,
                    AssinaturaTecnicoBase64 = os.AssinaturaTecnicoBase64,
                    PecasUtilizadas = os.PecasUtilizadas?.Select(p => new ItemPecaDTO
                    {
                        ProdutoID = p.ProdutoID,
                        Quantidade = p.Quantidade
                    }).ToList() ?? new List<ItemPecaDTO>()
                });
            }

            return ordensDeServicoDto;
        }

        public async Task<OrdemDeServicoDTO> GetOrdemDeServicoByIdAsync(string id)
        {
            var ordemDeServico = await _ordemDeServicoRepository.GetOrdemDeServicoByIdAsync(id);

            if (ordemDeServico == null)
            {
                return null;
            }

            return new OrdemDeServicoDTO
            {
                Id = ordemDeServico.Id,
                ClienteID = ordemDeServico.ClienteID,
                FuncionarioID = ordemDeServico.FuncionarioID,
                ProdutoIDs = ordemDeServico.ProdutoIDs,
                ServicoIDs = ordemDeServico.ServicoIDs,
                DataEntrada = ordemDeServico.DataEntrada,
                DataConclusao = ordemDeServico.DataConclusao,
                Status = ordemDeServico.Status,
                Observacoes = ordemDeServico.Observacoes,
                Ativo = ordemDeServico.Ativo,
                DefeitoRelatado = ordemDeServico.DefeitoRelatado,
                Diagnostico = ordemDeServico.Diagnostico,
                LaudoTecnico = ordemDeServico.LaudoTecnico,
                Marca = ordemDeServico.Marca,
                Modelo = ordemDeServico.Modelo,
                IMEIouSerial = ordemDeServico.IMEIouSerial,
                SenhaAcesso = ordemDeServico.SenhaAcesso,
                EmGarantia = ordemDeServico.EmGarantia,
                DataGarantia = ordemDeServico.DataGarantia,
                ValorMaoDeObra = ordemDeServico.ValorMaoDeObra,
                ValorPecas = ordemDeServico.ValorPecas,
                ValorTotal = ordemDeServico.ValorTotal,
                FormaPagamento = ordemDeServico.FormaPagamento,
                Pago = ordemDeServico.Pago,
                TipoAtendimento = ordemDeServico.TipoAtendimento,
                Prioridade = ordemDeServico.Prioridade,
                NumeroOS = ordemDeServico.NumeroOS,
                AssinaturaClienteBase64 = ordemDeServico.AssinaturaClienteBase64,
                AssinaturaTecnicoBase64 = ordemDeServico.AssinaturaTecnicoBase64,
                PecasUtilizadas = ordemDeServico.PecasUtilizadas?.Select(p => new ItemPecaDTO
                {
                    ProdutoID = p.ProdutoID,
                    Quantidade = p.Quantidade
                }).ToList() ?? new List<ItemPecaDTO>()
            };
        }

        public async Task<IEnumerable<OrdemDeServicoDTO>> GetOrdensDeServicoAtivasAsync()
        {
            var ordensDeServicoAtivas = await _ordemDeServicoRepository.GetOrdensDeServicoAtivasAsync();
            var ordensDeServicoAtivasDto = new List<OrdemDeServicoDTO>();

            foreach (var os in ordensDeServicoAtivas)
            {
                ordensDeServicoAtivasDto.Add(new OrdemDeServicoDTO
                {
                    Id = os.Id,
                    ClienteID = os.ClienteID,
                    FuncionarioID = os.FuncionarioID,
                    ProdutoIDs = os.ProdutoIDs,
                    ServicoIDs = os.ServicoIDs,
                    DataEntrada = os.DataEntrada,
                    DataConclusao = os.DataConclusao,
                    Status = os.Status,
                    Observacoes = os.Observacoes,
                    Ativo = os.Ativo,
                    PecasUtilizadas = os.PecasUtilizadas?.Select(p => new ItemPecaDTO
                    {
                        ProdutoID = p.ProdutoID,
                        Quantidade = p.Quantidade
                    }).ToList() ?? new List<ItemPecaDTO>()
                });
            }

            return ordensDeServicoAtivasDto;
        }

        public async Task<string> InsertOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto)
        {
            _ = ordemDeServicoDto ?? throw new ArgumentNullException(nameof(ordemDeServicoDto));

            var ordemDeServico = new OrdemDeServico
            {
                Id = string.IsNullOrEmpty(ordemDeServicoDto.Id) ? ObjectId.GenerateNewId().ToString() : ordemDeServicoDto.Id,
                ClienteID = ordemDeServicoDto.ClienteID,
                FuncionarioID = ordemDeServicoDto.FuncionarioID,
                ProdutoIDs = ordemDeServicoDto.ProdutoIDs,
                ServicoIDs = ordemDeServicoDto.ServicoIDs,
                DataEntrada = ordemDeServicoDto.DataEntrada,
                DataConclusao = ordemDeServicoDto.DataConclusao,
                Status = ordemDeServicoDto.Status,
                Observacoes = ordemDeServicoDto.Observacoes,
                Ativo = ordemDeServicoDto.Ativo,
                DefeitoRelatado = ordemDeServicoDto.DefeitoRelatado,
                Diagnostico = ordemDeServicoDto.Diagnostico,
                LaudoTecnico = ordemDeServicoDto.LaudoTecnico,
                Marca = ordemDeServicoDto.Marca,
                Modelo = ordemDeServicoDto.Modelo,
                IMEIouSerial = ordemDeServicoDto.IMEIouSerial,
                SenhaAcesso = ordemDeServicoDto.SenhaAcesso,
                EmGarantia = ordemDeServicoDto.EmGarantia,
                DataGarantia = ordemDeServicoDto.DataGarantia,
                ValorMaoDeObra = ordemDeServicoDto.ValorMaoDeObra,
                ValorPecas = ordemDeServicoDto.ValorPecas,
                ValorTotal = ordemDeServicoDto.ValorTotal,
                FormaPagamento = ordemDeServicoDto.FormaPagamento,
                Pago = ordemDeServicoDto.Pago,
                TipoAtendimento = ordemDeServicoDto.TipoAtendimento,
                Prioridade = ordemDeServicoDto.Prioridade,
                NumeroOS = ordemDeServicoDto.NumeroOS,
                AssinaturaClienteBase64 = ordemDeServicoDto.AssinaturaClienteBase64,
                AssinaturaTecnicoBase64 = ordemDeServicoDto.AssinaturaTecnicoBase64,
                PecasUtilizadas = ordemDeServicoDto.PecasUtilizadas?.Select(p => new ItemPeca
                {
                    ProdutoID = p.ProdutoID,
                    Quantidade = p.Quantidade
                }).ToList() ?? new List<ItemPeca>()
            };

            await _ordemDeServicoRepository.InsertOrdemDeServicoAsync(ordemDeServico);

            return ordemDeServico.Id;
        }

        public async Task UpdateOrdemDeServicoAsync(OrdemDeServicoDTO ordemDeServicoDto)
        {
            _ = ordemDeServicoDto ?? throw new ArgumentNullException(nameof(ordemDeServicoDto));

            var ordemDeServico = new OrdemDeServico
            {
                Id = ordemDeServicoDto.Id,
                ClienteID = ordemDeServicoDto.ClienteID,
                FuncionarioID = ordemDeServicoDto.FuncionarioID,
                ProdutoIDs = ordemDeServicoDto.ProdutoIDs,
                ServicoIDs = ordemDeServicoDto.ServicoIDs,
                DataEntrada = ordemDeServicoDto.DataEntrada,
                DataConclusao = ordemDeServicoDto.DataConclusao,
                Status = ordemDeServicoDto.Status,
                Observacoes = ordemDeServicoDto.Observacoes,
                Ativo = ordemDeServicoDto.Ativo,
                DefeitoRelatado = ordemDeServicoDto.DefeitoRelatado,
                Diagnostico = ordemDeServicoDto.Diagnostico,
                LaudoTecnico = ordemDeServicoDto.LaudoTecnico,
                Marca = ordemDeServicoDto.Marca,
                Modelo = ordemDeServicoDto.Modelo,
                IMEIouSerial = ordemDeServicoDto.IMEIouSerial,
                SenhaAcesso = ordemDeServicoDto.SenhaAcesso,
                EmGarantia = ordemDeServicoDto.EmGarantia,
                DataGarantia = ordemDeServicoDto.DataGarantia,
                ValorMaoDeObra = ordemDeServicoDto.ValorMaoDeObra,
                ValorPecas = ordemDeServicoDto.ValorPecas,
                ValorTotal = ordemDeServicoDto.ValorTotal,
                FormaPagamento = ordemDeServicoDto.FormaPagamento,
                Pago = ordemDeServicoDto.Pago,
                TipoAtendimento = ordemDeServicoDto.TipoAtendimento,
                Prioridade = ordemDeServicoDto.Prioridade,
                NumeroOS = ordemDeServicoDto.NumeroOS,
                AssinaturaClienteBase64 = ordemDeServicoDto.AssinaturaClienteBase64,
                AssinaturaTecnicoBase64 = ordemDeServicoDto.AssinaturaTecnicoBase64,
                PecasUtilizadas = ordemDeServicoDto.PecasUtilizadas?.Select(p => new ItemPeca
                {
                    ProdutoID = p.ProdutoID,
                    Quantidade = p.Quantidade
                }).ToList() ?? new List<ItemPeca>()
            };

            await _ordemDeServicoRepository.UpdateOrdemDeServicoAsync(ordemDeServico);
        }

        public async Task DesativarOrdemDeServicoAsync(string id)
        {
            await _ordemDeServicoRepository.DesativarOrdemDeServicoAsync(id);
        }

        public async Task AtivarOrdemDeServicoAsync(string id)
        {
            await _ordemDeServicoRepository.AtivarOrdemDeServicoAsync(id);
        }
    }
}
