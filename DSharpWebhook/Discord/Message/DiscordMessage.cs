using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSharpWebhook.Discord.Message
{
    public struct DiscordMessage
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Enable/disable text-to-speech
        /// </summary>
        [JsonProperty("tts")]
        public string TTS { get; set; }

        /// <summary>
        /// Name of webhook profile
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Url of webhook profile avatar
        /// </summary>
        [JsonProperty("avatar_url")]
        public string Avatar { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }

        [JsonProperty("allowed_mentions", NullValueHandling = NullValueHandling.Ignore)]
        public AllowedMentions AllowedMentions { get; set; }
    }
}
