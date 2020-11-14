using CooperlinkLocationWorker.Domain.Collections;
using Newtonsoft.Json;
using System;

namespace CooperlinkLocationWorker.Domain.Models
{
    [BsonCollectionAttribute("Vehicle")]
    public class Vehicle : CollectionModel
    {
        [JsonProperty("tipo")]
        public int Type { get; set; }

        [JsonProperty("tempoTransmissaoLigado")]
        public int TimeTramissionOn { get; set; }

        [JsonProperty("condutorNome")]
        public string ConductorNome { get; set; }

        [JsonProperty("tempoTransmissaoDesligado")]
        public int TimeTramissionOff { get; set; }

        [JsonProperty("cor")]
        public string Color { get; set; }

        [JsonProperty("alertaAncora")]
        public bool AlertAnchor { get; set; }

        [JsonProperty("modelo")]
        public string Model { get; set; }

        [JsonProperty("alertaIgnicao")]
        public bool AlertIgnition { get; set; }

        [JsonProperty("ultimaPosicao")]
        public LocationInfo LastLocation { get; set; }

        [JsonProperty("clienteNome")]
        public string ClientName { get; set; }

        [JsonProperty("id")]
        public long IdVehicle { get; set; }

        [JsonProperty("anoModelo")]
        public int YearModel { get; set; }

        [JsonProperty("equipamentoTelefone")]
        public string EquipmentPhone { get; set; }

        [JsonProperty("placa")]
        public string Board { get; set; }

        [JsonProperty("equipamentoCodigo")]
        public string EquipmentCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public Vehicle()
        {
            CreatedAt = DateTime.Now;
        }

    }
}
