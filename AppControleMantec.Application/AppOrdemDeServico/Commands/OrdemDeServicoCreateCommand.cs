using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoCreateCommand : IRequest<bool>
    {
        [BsonElement("ClienteID")]
        [BsonRepresentation(BsonType.String)]
        public string? ClienteID { get; set; }

        [BsonElement("FuncionarioID")]
        [BsonRepresentation(BsonType.String)]
        public string? FuncionarioID { get; set; }

        [BsonElement("ProdutoIDs")]
        public List<string> ProdutoIDs { get; set; } = new List<string>();

        [BsonElement("ServicoIDs")]
        public List<string> ServicoIDs { get; set; } = new List<string>();

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("DataConclusao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DataConclusao { get; set; }

        [BsonElement("Status")]
        public string? Status { get; set; }

        [BsonElement("Observacoes")]
        public string? Observacoes { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        // Campos técnicos
        [BsonElement("DefeitoRelatado")]
        public string? DefeitoRelatado { get; set; }

        [BsonElement("Diagnostico")]
        public string? Diagnostico { get; set; }

        [BsonElement("LaudoTecnico")]
        public string? LaudoTecnico { get; set; }

        // Dados do aparelho
        [BsonElement("Marca")]
        public string? Marca { get; set; }

        [BsonElement("Modelo")]
        public string? Modelo { get; set; }

        [BsonElement("IMEIouSerial")]
        public string? IMEIouSerial { get; set; }

        [BsonElement("SenhaAcesso")]
        public string? SenhaAcesso { get; set; }

        // Garantia
        [BsonElement("EmGarantia")]
        public bool EmGarantia { get; set; }

        [BsonElement("DataGarantia")]
        public DateTime? DataGarantia { get; set; }

        // Pagamento
        [BsonElement("ValorMaoDeObra")]
        public decimal ValorMaoDeObra { get; set; }

        [BsonElement("ValorPecas")]
        public decimal ValorPecas { get; set; }

        [BsonElement("ValorTotal")]
        public decimal ValorTotal { get; set; }

        [BsonElement("FormaPagamento")]
        public string? FormaPagamento { get; set; }

        [BsonElement("Pago")]
        public bool Pago { get; set; }

        // Prioridade e atendimento
        [BsonElement("TipoAtendimento")]
        public string? TipoAtendimento { get; set; }

        [BsonElement("Prioridade")]
        public string? Prioridade { get; set; }

        [BsonElement("NumeroOS")]
        public int NumeroOS { get; set; }

        // Assinaturas (imagem base64, ou hash de aprovação)
        [BsonElement("AssinaturaClienteBase64")]
        public string? AssinaturaClienteBase64 { get; set; }

        [BsonElement("AssinaturaTecnicoBase64")]
        public string? AssinaturaTecnicoBase64 { get; set; }

        // Peças utilizadas (com quantidade)
        [BsonElement("PecasUtilizadas")]
        public List<ItemPecaCommandDTO> PecasUtilizadas { get; set; } = new List<ItemPecaCommandDTO>();
    }

    public class ItemPecaCommandDTO
    {
        [BsonElement("ProdutoID")]
        public string ProdutoID { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }
    }
}
