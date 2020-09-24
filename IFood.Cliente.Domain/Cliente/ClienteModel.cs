using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IFood.Cliente.Domain.Cliente
{
    public class ClienteModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public Contato Contato { get; set; }
        public Endereco Endereco {get;set;}

    }
    public class Contato { 
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
    
    }

    public class Endereco {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public string Tipo {get;set;}
    }
}
