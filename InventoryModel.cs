using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Bot
{
    public class InventoryModel
    {
        [JsonProperty("success")]
        public string Success;

        [JsonProperty("value")]
        public string Value;

        [JsonProperty("items")]
        public string Items;

        [JsonProperty("currency")]
        public string Currency;
    }
}
