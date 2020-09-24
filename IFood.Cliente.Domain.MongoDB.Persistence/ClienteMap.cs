using MongoDB.Bson.Serialization;
using IFood.Cliente.Domain.Cliente;

namespace IFood.Cliente.Domain.MongoDB.Persistence
{
    public class ClienteMap
    {
        public void Configure()
        {
            BsonClassMap.RegisterClassMap<Cliente>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);

            });
        }
    }
}
