
using jubo_project_api.Entities;
using MongoDB.Driver;

namespace jubo_project_api.Infrastructure
{
    public class PatientOrderContext : MongoContext
    {
        public const string DEFAULT_SCHEMA = "PatientOrder";
        public readonly IMongoCollection<Order> Orders;
        public readonly IMongoCollection<Patient> Patients;
        public readonly IMongoCollection<Counter> Counters;

        public PatientOrderContext(IConfiguration configuration) 
            : base(configuration.GetConnectionString("MongoDB"),
            DEFAULT_SCHEMA)
        {
            Orders = GetCollection<Order>(nameof(Order));
            Patients = GetCollection<Patient>(nameof(Patient));
            Counters = GetCollection<Counter>(nameof(Counter));
        }
    }
}
