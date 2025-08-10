using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Queries
{
    public class OrdemDeServicoGetAllQuery : IRequest<IEnumerable<OrdemDeServicoDTO>>
    {
        // A consulta não precisa de parâmetros adicionais para recuperar todas as ordens de serviço
        // Caso queira filtrar ou personalizar a consulta, pode adicionar propriedades aqui no futuro.
    }
}
