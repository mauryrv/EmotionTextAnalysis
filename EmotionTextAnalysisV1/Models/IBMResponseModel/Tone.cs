using System;
using Newtonsoft.Json;

namespace EmotionTextAnalysisV1.Models.IBMResponseModel
{
    public class Tone
    {
        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("tone_id")]
        public string ToneId { get; set; }

        [JsonProperty("tone_name")]
        public string ToneName { get; set; }

    }
}
