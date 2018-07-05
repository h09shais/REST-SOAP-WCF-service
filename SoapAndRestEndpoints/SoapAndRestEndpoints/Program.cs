namespace SoapAndRestEndpoints
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json;
    using SimpleService;
    class Program
    {
        static void Main(string[] args)
        {
            var soapClient = new SimpleServiceClient();
            var soapResponse = soapClient.GetData(4234);
            if (soapResponse != null) Console.WriteLine(soapResponse);

            var request = new AuthenticationRequest
            {
                Username = "name",
                Password = "password"
            };
            var soapResponse2 = soapClient.Authenticate(request);
            soapClient.Close();

            using (var restClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:63852/SimpleService.svc/json/")
            })
            {
                var serilized = JsonConvert.SerializeObject(request);
                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent(serilized, Encoding.UTF8, "application/json")
                };
                inputMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = restClient.PutAsync("AuthReq", inputMessage.Content).Result;
                AuthorizationResponse restResponse = null;
                if (message.IsSuccessStatusCode)
                {
                    var inter = message.Content.ReadAsStringAsync();
                    restResponse = JsonConvert.DeserializeObject<AuthorizationResponse>(inter.Result);
                }

                if (restResponse != null) Console.WriteLine(restResponse.Message);
            }

            Console.ReadKey();
        }
    }

    public class AuthorizationResponse
    {
        public bool Valid { get; set; }
        public string Message { get; set; }
        public DateTime? ValidToDate { get; set; }
        public string ServerUrl { get; set; }
    }
}
