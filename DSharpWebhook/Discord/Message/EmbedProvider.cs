using Newtonsoft.Json;

namespace DSharpWebhook.Discord.Message
{
    public struct EmbedProvider
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }
}
