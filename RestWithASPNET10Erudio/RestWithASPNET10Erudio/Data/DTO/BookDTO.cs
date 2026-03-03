using RestWithASPNET10Erudio.JsonSerializers;
using System.Text.Json.Serialization;

namespace RestWithASPNET10Erudio.Data.DTO
{ 
    public class BookDTO 
    {                     
        public long Id { get; set; }
        public string Title { get; set; }     
        public string Author { get; set; }            
        public decimal Price { get; set; }

        [JsonConverter(typeof(DateSerializer))]
        public DateTime? LaunchDate { get; set; }
    }
}
