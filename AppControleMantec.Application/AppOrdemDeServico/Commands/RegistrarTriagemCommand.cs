using MediatR;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class RegistrarTriagemCommand : IRequest<bool>
    {
        public string OrdemId { get; set; } = null!;
        public TriagemDTO Triagem { get; set; } = null!;
    }
}
