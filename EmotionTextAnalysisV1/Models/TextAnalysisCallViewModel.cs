using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmotionTextAnalysisV1.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TextAnalysisCallViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Language { get; set; }

    }


}
