using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DtiBackend.Models
{
    public class Cliente
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
    }
}
