using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmotionTextAnalysisV1.Models.IBMResponseModel
{
    public class DocumentTone
    {
        [JsonProperty("tones")]
        public List<Tone> Tones { get; set; }
    }
}
