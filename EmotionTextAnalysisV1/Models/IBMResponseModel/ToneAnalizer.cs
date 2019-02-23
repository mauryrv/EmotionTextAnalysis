using System;
using System.Collections.Generic;

namespace EmotionTextAnalysisV1.Models.IBMResponseModel
{
    public class ToneAnalizer
    {
        public DocumentTone document_tone { get; set; }
        public List<SentencesTone> sentences_tone { get; set; }
    }
}
