using System;
using System.Text.Json.Serialization;

namespace RestWithASPNET.Model
{
    public class BookVO
    {
        [JsonPropertyName("Codigo")]
        public long? Id { get; set; }

        [JsonPropertyName("Titulo")]
        public string Title { get; set; }

        public string Author { get; set; }

        [JsonIgnore]
        public decimal Price { get; set; }

        [JsonPropertyName("Data")]
        public DateTime LaunchDate { get; set; }
    }
}
