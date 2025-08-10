using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class OrdemDeServico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ClienteID")]
        [BsonRepresentation(BsonType.String)]
        public string ? ClienteID { get; set; }

        [BsonElement("FuncionarioID")]
        [BsonRepresentation(BsonType.String)]
        public string ? FuncionarioID { get; set; }

        [BsonElement("ProdutoIDs")]
        public List<string> ? ProdutoIDs { get; set; } = new();

        [BsonElement("ServicoIDs")]
        public List<string> ServicoIDs { get; set; } = new();

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("DataConclusao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DataConclusao { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        // Campos técnicos
        public string DefeitoRelatado { get; set; }
        public string Diagnostico { get; set; }
        public string LaudoTecnico { get; set; }

        // Dados do aparelho
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string IMEIouSerial { get; set; }
        public string SenhaAcesso { get; set; }

        // Garantia
        public bool EmGarantia { get; set; }
        public DateTime? DataGarantia { get; set; }

        // Pagamento
        public decimal ValorMaoDeObra { get; set; }
        public decimal ValorPecas { get; set; }
        public decimal ValorTotal { get; set; }
        public string FormaPagamento { get; set; }
        public bool Pago { get; set; }

        // Prioridade e atendimento
        public string TipoAtendimento { get; set; } // Loja física, externo, etc.
        public string Prioridade { get; set; } // Alta, média, baixa
        public int NumeroOS { get; set; }

        // Assinaturas (imagem base64, ou hash de aprovação)
        public string AssinaturaClienteBase64 { get; set; }
        public string AssinaturaTecnicoBase64 { get; set; }

        // Peças utilizadas (com quantidade)
        public List<ItemPeca> PecasUtilizadas { get; set; } = new();

        // Relacionamentos ignorados no Mongo
        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Cliente Cliente { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Funcionario Funcionario { get; set; }

        #region Construtores

        public OrdemDeServico() { }

        public OrdemDeServico(string clienteID, string funcionarioID, List<string> servicoIDs, DateTime dataEntrada, string status, string observacoes)
        {
            ValidateDomain(clienteID, funcionarioID, servicoIDs, dataEntrada, status, observacoes);
            ClienteID = clienteID;
            FuncionarioID = funcionarioID;
            ServicoIDs = servicoIDs;
            DataEntrada = dataEntrada;
            Status = status;
            Observacoes = observacoes;
            Ativo = true;
        }

        public OrdemDeServico(string id, string clienteID, string funcionarioID, List<string> produtoIDs, List<string> servicoIDs, DateTime dataEntrada, DateTime? dataConclusao, string status, string observacoes, bool ativo)
        {
            Id = id;
            ClienteID = clienteID;
            FuncionarioID = funcionarioID;
            ProdutoIDs = produtoIDs;
            ServicoIDs = servicoIDs;
            DataEntrada = dataEntrada;
            DataConclusao = dataConclusao;
            Status = status;
            Observacoes = observacoes;
            Ativo = ativo;
        }

        #endregion

        #region Métodos Públicos

        public void ConcluirOrdem(DateTime dataConclusao)
        {
            DataConclusao = dataConclusao;
            Status = "Concluída";
        }

        public void CancelarOrdem()
        {
            Status = "Cancelada";
            Ativo = false;
        }

        public void AtualizarStatus(string novoStatus)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(novoStatus), "Status inválido.");
            Status = novoStatus;
        }

        #endregion

        #region Métodos Privados de Validação

        private void ValidateDomain(string clienteID, string funcionarioID, List<string> servicoIDs, DateTime dataEntrada, string status, string observacoes)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(clienteID) || clienteID == "0", "Cliente inválido. Selecione um cliente válido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(funcionarioID), "Funcionário inválido. Selecione um funcionário válido.");
            DomainExceptionValidation.When(servicoIDs == null || servicoIDs.Count == 0, "Serviço inválido. Selecione ao menos um serviço.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(status), "Status inválido. O status é obrigatório.");
            DomainExceptionValidation.When(status.Length > 50, "Status inválido. O status deve ter no máximo 50 caracteres.");

            Status = status;
            Observacoes = observacoes;
        }

        #endregion
    }

    public class ItemPeca
    {
        public string ProdutoID { get; set; }
        public int Quantidade { get; set; }
    }

}
