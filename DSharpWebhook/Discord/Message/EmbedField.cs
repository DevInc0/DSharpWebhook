using Newtonsoft.Json;

namespace DSharpWebhook.Discord.Message
{
    public struct EmbedField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("inline", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsInline { get; set; }
    }
}
