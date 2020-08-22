﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace CSGO_Bot
{
    public class Datum
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

    public class Root
    {
        public List<Datum> data { get; set; }
    }


    public class StatsAPI
    {
        static string apiString = "https://public-api.tracker.gg/v2/csgo/standard/search?platform=steam&query=";

        static HttpClient client = new HttpClient();

        public static async Task<Root> GetStatsAsync(string steamID)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("TRN-Api-Key", "100a7ea1-7e84-4a3c-a998-a31f89ae0718");
            Root root = null;
            HttpResponseMessage response = await client.GetAsync(apiString + steamID);
            if (response.IsSuccessStatusCode)
            {
                root = await response.Content.ReadAsAsync<Root>();
            }
            return root;
        }
    }
}