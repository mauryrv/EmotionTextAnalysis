using System;
using System.Threading.Tasks;
using EmotionTextAnalysisV1.Helper;
using RestSharp;
using RestSharp.Authenticators;

namespace EmotionTextAnalysisV1.Services
{
    public class IBMToneAnalizerService
    {
        public IBMToneAnalizerService()
        {
        }

        public async Task<IRestResponse> GetToneAnalizer(string text, string language)
        {
            var client = new RestClient(IBMHelper.Url);

            client.Authenticator = new HttpBasicAuthenticator(IBMHelper.ApiUser, IBMHelper.ApiKey);

            var request = new RestRequest(IBMHelper.GetToneAnalizer, Method.GET);

            if (!string.IsNullOrEmpty(language))
            {
                request.AddHeader("Content-Language", language);
            }

            request.AddHeader("content-type", "application/json");

            request.AddQueryParameter("text", text);
            request.AddQueryParameter("version", IBMHelper.ApiVersion);

            request.RequestFormat = DataFormat.Json;

            return client.Execute(request);
        }
    }
}
