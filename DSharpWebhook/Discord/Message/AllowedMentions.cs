using Newtonsoft.Json;
using System.Collections.Generic;

namespace DSharpWebhook.Discord.Message
{
    public sealed class AllowedMentions
    {
        /// <summary>
        /// List of allowed mention types
        /// </summary>
        [JsonProperty("parse")]
        public List<string> Parse { get; set; }

        /// <summary>
        /// Roles IDs to mention
        /// </summary>
        [JsonProperty("roles", NullValueHandling = NullValueHandling.Ignore)]
        public List<ulong> Roles { get; set; }

        /// <summary>
        /// Users IDs to mention
        /// </summary>
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<ulong> Users { get; set; }
    }
}
