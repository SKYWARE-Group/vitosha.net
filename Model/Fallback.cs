using System.Text.Json.Serialization;

namespace VitoshaClient.Model
{
    public class Fallback
    {

        [JsonPropertyName("SMS")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Sms { get; set; }

    }
}
