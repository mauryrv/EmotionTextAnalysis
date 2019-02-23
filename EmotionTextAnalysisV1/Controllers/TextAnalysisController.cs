using System.Net;
using System.Threading.Tasks;
using EmotionTextAnalysisV1.Models;
using EmotionTextAnalysisV1.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using EmotionTextAnalysisV1.Models.IBMResponseModel;
using EmotionTextAnalysisV1.Models.GoogleTranslateModel;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmotionTextAnalysisV1.Controllers
{
    public class TextAnalysisController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult TextAnalysisCall()
        {
            return View(new TextAnalysisCallViewModel());
        }


        [HttpPost]
        public IActionResult TextAnalysisCall(TextAnalysisCallViewModel textAnalysisCallViewModel)
        {

            //manda a setença pro google e verifica qual a linguagem, se for diferente de en ou fr, traduz pra en e retorna o texto em ingles.



            var IBMToneAnalizerService = new IBMToneAnalizerService();
            var googleTranslateService = new GoogleTranslateApiService();

            IRestResponse resultFromGoogleTranslate = googleTranslateService.GetTextTranslationFromGoogle(textAnalysisCallViewModel.Text);

            var googleTranslate = JsonConvert.DeserializeObject<GoogleTranslateModel>(resultFromGoogleTranslate.Content);

            IRestResponse resultFromToneAnalizer = IBMToneAnalizerService.GetToneAnalizer(googleTranslate.data.translations.FirstOrDefault().translatedText
            , textAnalysisCallViewModel.Language);

            //HttpStatusCode statusCode = resultFromToneAnalizer.StatusCode;

             var toneAnalizer = JsonConvert.DeserializeObject<ToneAnalizer>(resultFromToneAnalizer.Content);

            return View(new TextAnalysisResponseViewModel());
        }


    }
}
