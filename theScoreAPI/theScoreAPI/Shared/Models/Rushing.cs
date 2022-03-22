using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace theScoreAPI.Shared.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Rushing
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "Player")]
		public string Player { get; set; } = String.Empty;

		[JsonProperty(PropertyName = "Team")]
		public string Team { get; set; } = String.Empty;

		[JsonProperty(PropertyName = "Pos")]
		public string Pos { get; set; } = String.Empty;

		[JsonProperty(PropertyName = "Att")]
		public decimal Att { get; set; }

		[JsonProperty(PropertyName = "Att/G")]
		public decimal AttG { get; set; }

		[JsonProperty(PropertyName = "Yds")]
		public decimal Yds { get; set; }

		[JsonProperty(PropertyName = "Yds/G")]
		public decimal YdsG { get; set; }

		[JsonProperty(PropertyName = "Avg")]
		public decimal Avg { get; set; }

		[JsonProperty(PropertyName = "TD")]
		public decimal TD { get; set; }

		[JsonProperty(PropertyName = "Lng")]
		public string Lng { get; set; } = String.Empty;

		[JsonProperty(PropertyName = "LngDistance")]
		public int LngDistance { get; set; }

		[JsonProperty(PropertyName = "1st")]
		public decimal FirstDowns { get; set; }

		[JsonProperty(PropertyName = "1st%")]
		public decimal FirstDownPercent { get; set; }

		[JsonProperty(PropertyName = "20+")]
		public decimal RushingTwenty { get; set; }

		[JsonProperty(PropertyName = "40+")]
		public decimal RushingFourty { get; set; }

		[JsonProperty(PropertyName = "FUM")]
		public decimal FUM { get; set; }
	}
}
