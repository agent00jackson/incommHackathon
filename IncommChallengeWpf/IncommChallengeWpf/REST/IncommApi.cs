using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using IncommChallengeWpf.DataTypes;
using System.Net;
using Newtonsoft.Json.Linq;

namespace IncommChallengeWpf.REST
{
    public class IncommApi
    {
        HttpClient client = new HttpClient();
        private readonly string BaseURL = @"https://us-central1-incomm-hackathon-api.cloudfunctions.net/api/";
        private readonly string ApiKey;
        public IncommApi(string apiKey = "")
        {
            this.ApiKey = apiKey;
            client.DefaultRequestHeaders.Add("X-API-Key", "ufBsC0wSbhTkLrB2jUdL");
        }

        public async Task<List<IncommAcct>> GetAccounts()
        {
            var requestResult = await client.GetAsync($"{BaseURL}accounts");
            var responseText = await requestResult.Content.ReadAsStringAsync();
            var jResponse = JObject.Parse(responseText)["accounts"];

            List<IncommAcct> accts = new List<IncommAcct>();
            foreach(var a in jResponse)
            {
                string id = (string)a["id"];
                string owner = a["owner"]?.Value<string>() ?? "";//if null then empty
                int balance = (int)a["balance"];

                var account = new IncommAcct(id, owner, balance);
                accts.Add(account);
            }

            return accts;
        }
    }
}
