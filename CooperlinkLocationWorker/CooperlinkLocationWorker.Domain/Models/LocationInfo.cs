using CooperlinkLocationWorker.Domain.Collections;
using CooperlinkLocationWorker.Domain.Enum;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace CooperlinkLocationWorker.Domain.Models
{
    [BsonCollectionAttribute("LocationInfo")]
    public class LocationInfo
    {
        [JsonProperty("sateliteNumero")]
        public double SatelliteNumber { get; set; }

        [JsonProperty("cidade")]
        public string City { get; set; }

        [JsonProperty("estado")]
        public string State { get; set; }

        [BsonIgnore]
        public EIgnition Ignition { get => IgnitionString == "LIGADA" ? EIgnition.ON : EIgnition.OFF; }

        [JsonProperty("velocidade")]
        public int Speed { get; set; }

        [JsonProperty("endereco")]
        public string Address { get; set; }

        [JsonProperty("numero")]
        public string Number { get; set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("ultimaTrasmissao")]
        public string LastTransmission { get; set; }

        [JsonProperty("direcao")]
        public string Direction { get; set; }

        [JsonProperty("ignicao")]
        public string IgnitionString { get; set; }

        [JsonProperty("equipamentoDataEnvio")]
        public string EquipmentDataShipping { get; set; }

        [JsonProperty("precisao")]
        public string Precision { get; set; }

        [JsonProperty("voltagemBateriaBackup")]
        public double VoltageBatteryBackup { get; set; }

        [JsonProperty("voltagem")]
        public double Voltage { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dataCadastro")]
        public string DateRegister { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("hodometro")]
        public double Hodometro { get; set; }
    }
}
