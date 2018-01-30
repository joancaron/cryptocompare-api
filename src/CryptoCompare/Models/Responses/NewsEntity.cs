using Newtonsoft.Json;

namespace CryptoCompare
{
    public class NewsEntity
    {
		[JsonProperty("id")]
		public long Id { get; set; }
	    [JsonProperty("guid")]
		public string Guid { get; set; }
	    [JsonProperty("published_on")]
	    public long PublishDateUnix { get; set; }
	    [JsonProperty("imageurl")]
	    public string ImageUrl { get; set; }
	    [JsonProperty("title")]
	    public string Title { get; set; }
	    [JsonProperty("url")]
	    public string Url { get; set; }
	    [JsonProperty("source")]
	    public string Source { get; set; }
	    [JsonProperty("body")]
	    public string Body { get; set; }
	    [JsonProperty("tags")]
	    public string TagsString { get; set; }
	    [JsonProperty("lang")]
	    public string Lang { get; set; }
		[JsonProperty("source_info")]
		public NewsProvider SourceInfo { get; set; }

    }


}
