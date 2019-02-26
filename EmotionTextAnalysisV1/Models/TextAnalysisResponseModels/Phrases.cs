using System;
using System.Collections.Generic;

namespace EmotionTextAnalysisV1.Models.TextAnalysisResponseModels
{
    public class Phrases
    {
        public string Text { get; set; }
        public List<Feelings> Feelings { get; set; }
    }
}
