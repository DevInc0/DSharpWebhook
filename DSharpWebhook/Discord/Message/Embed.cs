using DSharpWebhook.Discord.Colors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DSharpWebhook.Discord.Message
{
    public struct Embed
    {
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonIgnore]
        public DateTime? Timestamp
        {
            get => DateTime.Parse(StringTimestamp);
            set => StringTimestamp = value?.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffffffzzz");
        }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public string StringTimestamp { get; private set; }

        [JsonIgnore]
        public Color? Color
        {
            get => DecimalColor.HasValue ? new Color(DecimalColor.Value) : default;
            set => DecimalColor = value?.Value;
        }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public int? DecimalColor { get; private set; }

        [JsonProperty("footer", NullValueHandling = NullValueHandling.Ignore)]
        public Footer Footer { get; set; }

        [JsonProperty("image", NullValueHandling = NullValueHandling.Ignore)]
        public Media Image { get; set; }

        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public Media Thumbnail { get; set; }

        [JsonProperty("video", NullValueHandling = NullValueHandling.Ignore)]
        public Media Video { get; set; }

        [JsonProperty("provider", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedProvider Provider { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        public Author Author { get; set; }

        [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
        public List<EmbedField> Fields { get; set; }
    }
}
