using theScoreAPI.Shared.Models;

namespace theScoreAPI.BusinessServices
{
	public interface IRushingService
	{
        Task<RushingDTO> GetRushings(RushingSearch search);
        Task<RushingDTO> PostRushings();
    }
}
