using MediatR;
using System.Collections.Generic;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Queries
{
    public class OrdemDeServicoGetAtivasQuery : IRequest<IEnumerable<OrdemDeServicoDTO>>
    {
        // Esta classe ainda não requer parâmetros adicionais. 
        // Caso no futuro você queira filtrar por outros campos (ex: tipo de atendimento, cliente, etc.), pode adicionar propriedades aqui.
    }
}
