using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading;

namespace CSGO_Bot
{
    public class User
    {
        public int platformId { get; set; }
        public string platformSlug { get; set; }
        public string platformUserIdentifier { get; set; }
        public string platformUserId { get; set; }
        public string platformUserHandle { get; set; }
        public string avatarUrl { get; set; }
        public object additionalParameters { get; set; }

        public override string ToString()
        {
            return "Username: " + platformUserHandle +
                "\n" + avatarUrl;
        }
    }

    public class UserRoot
    {
        [JsonProperty("data")]
        public List<User> users { get; set; }
    }


    public class StatsAPI
    {
        static string apiString = "https://public-api.tracker.gg/v2/csgo/standard";
        static string inventoryApiString = "http://csgobackpack.net/api/GetInventoryValue";
        static HttpClient client = new HttpClient();

        public static async Task<UserRoot> GetStatsAsync(string steamID)
        {
            string getStatsCommand = $"/search?platform=steam&query={steamID}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "100a7ea1-7e84-4a3c-a998-a31f89ae0718");
            UserRoot root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    root = await response.Content.ReadAsAsync<UserRoot>();
                    return root;
                }
                catch
                {
                    return null;
                }
            }
            return root;
        }

        public static async Task<Root> GetMapStatsAsync(string steamID)
        {
            string getStatsCommand = $"/profile/steam/{steamID}/segments/map";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "100a7ea1-7e84-4a3c-a998-a31f89ae0718");
            Root root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    root = await response.Content.ReadAsAsync<Root>();
                    return root;
                }
                catch
                {
                    return null;
                }
            }
            return root;
        }

        public static async Task<UserInfoRoot> GetUserStats(string steamID)
        {
            string getStatsCommand = $"/profile/steam/{steamID}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "100a7ea1-7e84-4a3c-a998-a31f89ae0718");
            UserInfoRoot root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    root = await response.Content.ReadAsAsync<UserInfoRoot>();
                    return root;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public static async Task<InventoryModel> GetInventoryStats(string steamID)
        {
            string getStatsCommand = $"/?id={steamID}";
            client.DefaultRequestHeaders.Clear();
            InventoryModel root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    root = await response.Content.ReadAsAsync<InventoryModel>();
                    return root;
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        //public static async Task<InventoryModel> GetInventoryStats(string steamID)
        //{
        //    string getStatsCommand = $"/?id={steamID}";
        //    InventoryModel root = null;
        //    var response = client.GetStringAsync(inventoryApiString + getStatsCommand);
        //    if (response != null)
        //    {
        //        root = JsonConvert.DeserializeObject<InventoryModel>(response.Result);
        //    }
        //    return root;

        //}
    }
}
