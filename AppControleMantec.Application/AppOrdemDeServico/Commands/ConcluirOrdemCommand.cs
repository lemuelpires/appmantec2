using MediatR;
using System;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class ConcluirOrdemCommand : IRequest<bool>
    {
        public string OrdemId { get; set; } = null!;
        public DateTime DataConclusao { get; set; }
    }
}
