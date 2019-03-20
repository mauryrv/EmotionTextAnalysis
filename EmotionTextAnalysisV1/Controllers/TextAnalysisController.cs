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
using EmotionTextAnalysisV1.Models.TextAnalysisResponseModels;
using System.Collections.Generic;
using System.Diagnostics;

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
        
            var IBMToneAnalizerService = new IBMToneAnalizerService();

            #region google Translate
            /*var googleTranslateService = new GoogleTranslateApiService();

            IRestResponse resultFromGoogleTranslate = googleTranslateService.GetTextTranslationFromGoogle(textAnalysisCallViewModel.Text);

            if (resultFromGoogleTranslate.StatusCode != HttpStatusCode.OK)
            {
                return View(new ErrorViewModel { RequestId = resultFromGoogleTranslate.Content ?? HttpContext.TraceIdentifier });
            }

            var googleTranslate = JsonConvert.DeserializeObject<GoogleTranslateModel>(resultFromGoogleTranslate.Content);*/
            //googleTranslate.data.translations.FirstOrDefault().translatedText
            #endregion

            IRestResponse resultFromToneAnalizer = IBMToneAnalizerService.GetToneAnalizer(textAnalysisCallViewModel.Text
            , textAnalysisCallViewModel.Language);

            var toneAnalizer = JsonConvert.DeserializeObject<ToneAnalizer>(resultFromToneAnalizer.Content);

            var textAnalysisResponseViewModel = new TextAnalysisResponseViewModel();

            if (resultFromToneAnalizer.StatusCode != HttpStatusCode.OK)
            {
                return View(new ErrorViewModel { RequestId = resultFromToneAnalizer.Content ?? HttpContext.TraceIdentifier });
            }

            textAnalysisResponseViewModel = TextAnalysisResponseViewModelMapper(toneAnalizer);
            textAnalysisResponseViewModel.Text = textAnalysisCallViewModel.Text;

            return View("textAnalysisResponse", textAnalysisResponseViewModel);
        }

        private TextAnalysisResponseViewModel TextAnalysisResponseViewModelMapper(ToneAnalizer toneAnalizer)
        {
            var textAnalysisResponseViewModel = new TextAnalysisResponseViewModel();
            var generalText = new GeneralText();
            var feelings = new List<Feelings>();
            var feelingsSetences = new List<Feelings>();
            var sentencesAnalysis = new List<Phrases>();

            if (toneAnalizer.document_tone != null)
            {
                if (toneAnalizer.document_tone.Tones.Count > 0)
                {

                    foreach(var tone in toneAnalizer.document_tone.Tones)
                    {
                        feelings.Add(new Feelings
                        {
                            Score = tone.Score,
                            FeelingName = tone.ToneName
                        });
                    }

                }
            }

            generalText.Feelings = feelings;
            textAnalysisResponseViewModel.GeneralText = generalText;


            if (toneAnalizer.sentences_tone != null)
            {
                if (toneAnalizer.sentences_tone.Count > 0)
                {
                    foreach (var setenceTone in toneAnalizer.sentences_tone)
                    {

                        if (setenceTone.Tones.Count > 0)
                        {
                            foreach (var tone in setenceTone.Tones)
                            {
                                feelingsSetences.Add(new Feelings
                                {
                                    Score = tone.Score,
                                    FeelingName = tone.ToneName
                                });
                            }

                        }

                        sentencesAnalysis.Add(new Phrases
                        {
                            Text = setenceTone.Text,
                            Feelings = feelingsSetences
                        });

                        feelingsSetences = new List<Feelings>();

                    }

                }
            }

            textAnalysisResponseViewModel.SentencesAnalysis = sentencesAnalysis;
            return textAnalysisResponseViewModel;
        }
    }
}
