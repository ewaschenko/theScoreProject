using Microsoft.AspNetCore.Mvc;

using theScoreAPI.BusinessServices;
using theScoreAPI.Shared.Models;

namespace theScoreAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RushingController : ControllerBase
	{
		private readonly ILogger<RushingController> _logger;
		private readonly IRushingService _rushingService;

		public RushingController(ILogger<RushingController> logger,IRushingService rushingService)
		{
			_logger = logger;
			_rushingService = rushingService;
		} 

		[HttpGet(Name = "GetRushing")]
		public async Task<ActionResult<RushingDTO>> Get([FromQuery] RushingSearch search)
		{
			return Ok(await _rushingService.GetRushings(search));
		}

		[HttpPost(Name = "PostRushing")]
		public async Task<ActionResult<RushingDTO>> Post()
		{
			return Ok(await _rushingService.PostRushings());
		}
	}
}
