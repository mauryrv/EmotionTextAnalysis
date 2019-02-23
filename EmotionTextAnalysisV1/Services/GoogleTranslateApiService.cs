using System;
using EmotionTextAnalysisV1.Helper;
using RestSharp;

namespace EmotionTextAnalysisV1.Services
{
    public class GoogleTranslateApiService
    {
        public GoogleTranslateApiService()
        {
        }

        public IRestResponse GetTextTranslationFromGoogle(string text)
        {
            var client = new RestClient(GoogleHelper.Url);

            var request = new RestRequest(GoogleHelper.Translate, Method.GET);

            request.AddHeader("content-type", "application/json");

            request.AddQueryParameter("q", text);
            request.AddQueryParameter("target", GoogleHelper.Language);
            request.AddQueryParameter("key", IBMHelper.ApiKey);

            request.RequestFormat = DataFormat.Json;

            return client.Execute(request);
        }

    }
}
