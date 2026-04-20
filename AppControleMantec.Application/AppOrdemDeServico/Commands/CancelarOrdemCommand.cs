using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class CancelarOrdemCommand : IRequest<bool>
    {
        public string OrdemId { get; set; } = null!;
    }
}
