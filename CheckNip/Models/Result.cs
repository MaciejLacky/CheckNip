using Newtonsoft.Json;

namespace CheckNip.Models
{
    public class Result
    {
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        [JsonProperty("requestDateTime")]
        public string RequestDateTime { get; set; }

        [JsonProperty("requestId")]
        public string RequestId { get; set; }
    }

    public class ResultRoot
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
    }
}
