using jubo_project_api.Infrastructure;
using jubo_project_api.Entities;
using MongoDB.Driver;

namespace jubo_project_api.Helpers
{
    public class MongoDbHelper(PatientOrderContext context)
    {
        public async Task<long> GetNextSequenceValueAsync(string sequenceName)
        {
            var filter = Builders<Counter>.Filter.Eq(c => c.Id, sequenceName);
            var update = Builders<Counter>.Update.Inc(c => c.SequenceValue, 1);
            var options = new FindOneAndUpdateOptions<Counter>
            {
                IsUpsert = true,
                ReturnDocument = ReturnDocument.After
            };

            var counter = await context.Counters.FindOneAndUpdateAsync(filter, update, options);
            return counter.SequenceValue;
        }
    }
}
