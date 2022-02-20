using Newtonsoft.Json;

namespace theScoreAPI.Shared.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class RushingDTO
	{
        public IEnumerable<Rushing>? Rushings { get; set; }

        public int TotalCount { get; set; }
    }
}
