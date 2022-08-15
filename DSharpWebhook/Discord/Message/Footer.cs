using Newtonsoft.Json;

namespace DSharpWebhook.Discord.Message
{
    public struct Footer
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string IconUrl { get; set; }

        [JsonProperty("proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
        public string ProxyIconUrl { get; set; }
    }
}
