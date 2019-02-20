using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace EmotionTextAnalysisV1.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TextAnalysisCallViewModel
    {
        public string Text { get; set; }
        public string Language { get; set; }

    }


}
