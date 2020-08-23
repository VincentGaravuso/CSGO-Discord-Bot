using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Bot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Attributes
    {
        [JsonProperty("key")]
        public string Key;
    }

    public class Metadata
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("imageUrl")]
        public string ImageUrl;
    }

    public class Metadata2
    {
    }

    public class Rounds
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public object Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("metadata")]
        public Metadata2 Metadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class Metadata3
    {
    }

    public class Wins
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public object Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("metadata")]
        public Metadata3 Metadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class Stats
    {
        [JsonProperty("rounds")]
        public Rounds Rounds;

        [JsonProperty("wins")]
        public Wins Wins;
    }

    public class Datum
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("attributes")]
        public Attributes Attributes;

        [JsonProperty("metadata")]
        public Metadata Metadata;

        [JsonProperty("expiryDate")]
        public DateTime ExpiryDate;

        [JsonProperty("stats")]
        public Stats Stats;
    }

    public class Root
    {
        [JsonProperty("data")]
        public List<Datum> Data;
    }


    public class StatsModel
    {

    }
}
