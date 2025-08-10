using AutoMapper;
using AppControleMantec.Application.AppCliente.Commands;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppEstoque.Commands;
using AppControleMantec.Application.AppFuncionario.Commands;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Application.AppProduto.Commands;
using AppControleMantec.Application.AppServico.Commands;

namespace AppControleMantec.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            // Mapeamento de Cliente
            CreateMap<ClienteCreateCommand, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ClienteUpdateCommand, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento de Produto
            CreateMap<ProdutoCreateCommand, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataEntrada, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ProdutoUpdateCommand, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataEntrada, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento de Serviço
            CreateMap<ServicoCreateCommand, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ServicoUpdateCommand, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento de Estoque
            CreateMap<EstoqueCreateCommand, Estoque>();
            CreateMap<EstoqueUpdateCommand, Estoque>();

            // Mapeamento de Funcionario
            CreateMap<FuncionarioCreateCommand, Funcionario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataContratacao, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<FuncionarioUpdateCommand, Funcionario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataContratacao, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento de OrdemDeServico
            CreateMap<OrdemDeServicoCreateCommand, OrdemDeServico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<OrdemDeServicoUpdateCommand, OrdemDeServico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            // Mapeamento de DTOs para entidades
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Servico, ServicoDTO>();
            CreateMap<Estoque, EstoqueDTO>();
            CreateMap<Funcionario, FuncionarioDTO>();
            CreateMap<OrdemDeServico, OrdemDeServicoDTO>();

            // Mapeamento de ItemPeca
            CreateMap<ItemPecaDTO, ItemPeca>().ReverseMap();
        }
    }
}
