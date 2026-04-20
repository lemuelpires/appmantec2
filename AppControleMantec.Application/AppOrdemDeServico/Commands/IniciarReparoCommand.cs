using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class IniciarReparoCommand : IRequest<bool>
    {
        public string OrdemId { get; set; } = null!;
    }
}
