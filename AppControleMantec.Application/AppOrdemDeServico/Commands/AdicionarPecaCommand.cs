using MediatR;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class AdicionarPecaCommand : IRequest<bool>
    {
        public string OrdemId { get; set; } = null!;
        public ItemPecaDTO Item { get; set; } = null!;
    }
}
