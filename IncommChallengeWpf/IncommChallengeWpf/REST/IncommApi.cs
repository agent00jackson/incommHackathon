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
        public IncommApi(string apiKey = "***REMOVED***")
        {
            this.ApiKey = apiKey;
            client.DefaultRequestHeaders.Add("X-API-Key", ApiKey);
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

        public async Task<List<IncommTransactions>> GetTransactionss(string accountId)
        {
            var requestResult = await client.GetAsync($"{BaseURL}/accounts/{accountId}/transactions");
            var responseText = await requestResult.Content.ReadAsStringAsync();
                var jResponse = JArray.Parse(responseText);

            List<IncommTransactions> transactions = new List<IncommTransactions>();
            foreach (var t in jResponse)
            {
                string id = (string)t["id"];
                string counterParty = t["counterParty"]?.Value<string>() ?? "";//if null then empty
                string type = (string)t["type"];
                string status = (string)t["status"];
                string description = (string)t["description"];
                int amount = (int)t["amount"];
                string date = (string)t["date"];

                var account = new IncommTransactions(id, counterParty, type, status, description, amount, date);
                transactions.Add(account);
            }

            return transactions;
        }
    }
}
