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

        static HttpClient client = new HttpClient();

        public static async Task<UserRoot> GetStatsAsync(string steamID)
        {
            string getStatsCommand = $"/search?platform=steam&query={steamID}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "[KEY]");
            UserRoot root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<UserRoot>();
            }
            return root;
        }

        public static async Task<Root> GetMapStatsAsync(string steamID)
        {
            string getStatsCommand = $"/profile/steam/{steamID}/segments/map";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "[KEY]");
            Root root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<Root>();
            }
            return root;

        }

        public static async Task<UserInfoRoot> GetUserStats(string steamID)
        {
            string getStatsCommand = $"/profile/steam/{steamID}";
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "[KEY]");
            UserInfoRoot root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + getStatsCommand);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<UserInfoRoot>();
            }
            return root;

        }
    }
}
