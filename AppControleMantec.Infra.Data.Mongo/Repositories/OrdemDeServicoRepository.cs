using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace AppControleMantec.Infra.Data.Mongo
{
    public class OrdemDeServicoRepository : IOrdemDeServicoRepository
    {
        private readonly IMongoCollection<OrdemDeServico> _ordemDeServicoCollection;

        public OrdemDeServicoRepository(IMongoClient mongoClient, IConfiguration configuration)
        {
            var databaseName = configuration.GetSection("DatabaseSettings:DatabaseName").Value;
            var database = mongoClient.GetDatabase(databaseName);
            _ordemDeServicoCollection = database.GetCollection<OrdemDeServico>("OrdensDeServico");
        }


        public async Task InsertOrdemDeServicoAsync(OrdemDeServico ordemDeServico)
        {
            await _ordemDeServicoCollection.InsertOneAsync(ordemDeServico);
        }

        public async Task<OrdemDeServico> GetOrdemDeServicoByIdAsync(string id)
        {
            var filter = Builders<OrdemDeServico>.Filter.Eq(os => os.Id, id);
            return await _ordemDeServicoCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task UpdateOrdemDeServicoAsync(OrdemDeServico ordemDeServico)
        {
            var filter = Builders<OrdemDeServico>.Filter.Eq(os => os.Id, ordemDeServico.Id);
            await _ordemDeServicoCollection.ReplaceOneAsync(filter, ordemDeServico);
        }

        public async Task DesativarOrdemDeServicoAsync(string id)
        {
            var filter = Builders<OrdemDeServico>.Filter.Eq(os => os.Id, id);
            var update = Builders<OrdemDeServico>.Update.Set(os => os.Ativo, false);
            await _ordemDeServicoCollection.UpdateOneAsync(filter, update);
        }

        public async Task AtivarOrdemDeServicoAsync(string id)
        {
            var filter = Builders<OrdemDeServico>.Filter.Eq(os => os.Id, id);
            var update = Builders<OrdemDeServico>.Update.Set(os => os.Ativo, true);
            await _ordemDeServicoCollection.UpdateOneAsync(filter, update);
        }

        public async Task<IEnumerable<OrdemDeServico>> GetOrdensDeServicoAsync()
        {
            return await _ordemDeServicoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<IEnumerable<OrdemDeServico>> GetOrdensDeServicoAtivasAsync()
        {
            var filter = Builders<OrdemDeServico>.Filter.Eq(os => os.Ativo, true);
            return await _ordemDeServicoCollection.Find(filter).ToListAsync();
        }
    }
}
