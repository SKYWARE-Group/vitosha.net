using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VitoshaClient.Helpers;
using VitoshaClient.Model;
using VitoshaWebModel.Model.Request;
using VitoshaWebModel.Model.Response;

namespace VitoshaClient.Clients
{
    public class VitoshaClient
    {

        public VitoshaClient() { }

        public VitoshaClient(string apiKey, string server, TimeSpan? timeout = null)
        {
            if(timeout is null) timeout = TimeSpan.FromMinutes(2);
            TimeOut = timeout.Value;
            ApiKey = apiKey;
            ServerUrl = server;
        }

        public string ApiKey { get; set; }
        public string ServerUrl { get; set; }
        public TimeSpan TimeOut { get; set; }

        public async Task<SkywareResponse> SendMessageAsync(Message msg)
        {
            if (msg is null) throw new ArgumentNullException(nameof(msg));
            var jsonMsg = JsonSerializer.Serialize(msg);
            using (var wc = new HttpClient() { Timeout = TimeOut })
            {
                wc.DefaultRequestHeaders.Add("x-api-key", ApiKey);
                var res = await wc.PostAsync(UrlHelper.Combine(ServerUrl, "api", "messages/"), new StringContent(jsonMsg, Encoding.UTF8, "application/json"));
                var resultContent = await res.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<SkywareResponse>(resultContent);
            }
        }

        public async Task<Message> GetMessageAsync(int id)
        {
            if (id <= 0) throw new ArgumentNullException(nameof(id));
            using (var wc = new HttpClient() { Timeout = TimeOut })
            {
                wc.DefaultRequestHeaders.Add("x-api-key", ApiKey);
                var res = await wc.GetAsync(UrlHelper.Combine(ServerUrl, "api", "messages/") + $"?id={id}");
                var resultContent = await res.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Message>(resultContent);
            }
        }

    }
}
