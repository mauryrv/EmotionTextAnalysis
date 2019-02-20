using System.Net;
using System.Threading.Tasks;
using EmotionTextAnalysisV1.Models;
using EmotionTextAnalysisV1.Services;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;

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

            //Aqui devo chamar a api da ibm para analisar o texto e com o retorno criar a pagina para mostrar  analise do texto!!!!!!
            var IBMToneAnalizerService = new IBMToneAnalizerService();
            IRestResponse result = IBMToneAnalizerService
            .GetToneAnalizer(textAnalysisCallViewModel.Text, textAnalysisCallViewModel.Language)
            .GetAwaiter()
            .GetResult();

            HttpStatusCode statusCode = result.StatusCode;

            TextAnalysisResponseViewModel toneAnalizer = JsonConvert.DeserializeObject<TextAnalysisResponseViewModel>(result.Content);

            return View(new TextAnalysisResponseViewModel());
        }


    }
}
