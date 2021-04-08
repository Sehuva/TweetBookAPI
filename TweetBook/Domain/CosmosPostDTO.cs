using Cosmonaut.Attributes;
using Newtonsoft.Json;

namespace TweetBook.Domain
{
    [CosmosCollection("posts")]
    public class CosmosPostDTO
    {
        [CosmosPartitionKey]
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}