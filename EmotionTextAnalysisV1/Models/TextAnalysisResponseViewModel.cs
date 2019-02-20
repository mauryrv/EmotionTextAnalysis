using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmotionTextAnalysisV1.Models.IBMResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace EmotionTextAnalysisV1.Models
{
    public class TextAnalysisResponseViewModel
    {
        public DocumentTone document_tone { get; set; }
        public List<SentencesTone> sentences_tone { get; set; }
    }
}
