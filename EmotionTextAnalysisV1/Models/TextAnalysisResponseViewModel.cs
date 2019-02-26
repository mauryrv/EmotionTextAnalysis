using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmotionTextAnalysisV1.Models.IBMResponseModel;
using EmotionTextAnalysisV1.Models.TextAnalysisResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace EmotionTextAnalysisV1.Models
{
    public class TextAnalysisResponseViewModel
    {
        public GeneralText GeneralText { get; set; }
        public List<Phrases> SentencesAnalysis { get; set; }
    }

}
