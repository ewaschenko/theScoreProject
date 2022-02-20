using Newtonsoft.Json;

namespace theScoreAPI.Shared.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class RushingSearch
    {
        [JsonProperty(PropertyName = "player")]
        public string? Player { get; set; } = "";

        [JsonProperty(PropertyName = "sort_value")]
        public string? SortValue { get; set; } = "";

        [JsonProperty(PropertyName = "sort_direction")]
        public string? SortDirection { get; set; } = "";

        [JsonProperty(PropertyName = "current_page")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "page_size")]
        public int PageSize { get; set; }
    }
}
