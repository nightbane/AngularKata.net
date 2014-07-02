using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AngularKata.Models
{
    public class PriorityModel
    {
        public int PriorityId { get; set; }
        public string Name { get; set; }
        public string Objective { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Segment Category { get; set; }
    }

    public enum Segment
    {
        Financial,
        Spiritual,
        Physical,
        Intellectual,
        Family,
        Social,
        Career,
    }
}