using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Domain.Interfaces
{
    public interface IOrdemDeServicoRepository
    {
        Task InsertOrdemDeServicoAsync(OrdemDeServico ordemDeServico);
        Task<OrdemDeServico> GetOrdemDeServicoByIdAsync(string id);  // Adicionei o método aqui
        Task UpdateOrdemDeServicoAsync(OrdemDeServico ordemDeServico);
        Task DesativarOrdemDeServicoAsync(string id);
        Task AtivarOrdemDeServicoAsync(string id);  // Adicionei o método aqui
        Task<IEnumerable<OrdemDeServico>> GetOrdensDeServicoAsync();
        Task<IEnumerable<OrdemDeServico>> GetOrdensDeServicoAtivasAsync();
    }
}
