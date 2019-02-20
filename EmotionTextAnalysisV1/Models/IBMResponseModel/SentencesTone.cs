using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmotionTextAnalysisV1.Models.IBMResponseModel
{
    public class SentencesTone
    {
        [JsonProperty("sentence_id")]
        public int SentenceId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("tones")]
        public List<Tone> Tones { get; set; }
    }
}
