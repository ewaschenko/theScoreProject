using System.IO;

using Microsoft.EntityFrameworkCore;

using theScoreAPI.Context;
using theScoreAPI.Shared.Const;
using theScoreAPI.Shared.Models;

using Newtonsoft.Json;

namespace theScoreAPI.BusinessServices
{
	public class RushingService : IRushingService
	{
		private readonly DataContext _dataContext;
		private readonly IConfiguration _config;

		public RushingService(DataContext dataContext, IConfiguration configuration)
		{
			_dataContext = dataContext;
			_config = configuration;
		}

		public async Task<RushingDTO> GetRushings(RushingSearch search)
		{
			IQueryable<Rushing> filterQuery = _dataContext.Rushings;

			if (!string.IsNullOrEmpty(search.Player))
			{
				filterQuery = filterQuery.Where(p => p.Player.Contains(search.Player));
			}

			if (!string.IsNullOrEmpty(search.SortValue) && !string.IsNullOrEmpty(search.SortDirection))
			{
				if (search.SortValue == Constants.TotalRushingYards)
				{
					if (search.SortDirection == Constants.Ascending)
					{
						filterQuery = filterQuery.OrderBy(o => o.Yds);
					}
					else
					{
						filterQuery = filterQuery.OrderByDescending(o => o.Yds);
					}
				}
				else if (search.SortValue == Constants.TotalRushingTouchdowns)
				{
					if (search.SortDirection == Constants.Ascending)
					{
						filterQuery = filterQuery.OrderBy(o => o.TD);
					}
					else
					{
						filterQuery = filterQuery.OrderByDescending(o => o.TD);
					}
				}
				else if (search.SortValue == Constants.LongestRush)
				{
					if (search.SortDirection == Constants.Ascending)
					{
						filterQuery = filterQuery.OrderBy(o => o.LngDistance);
					}
					else
					{
						filterQuery = filterQuery.OrderByDescending(o => o.LngDistance);
					}
				}
			}
		   
			int totalCount = filterQuery.Count();
			filterQuery = filterQuery.Skip(search.PageSize * search.CurrentPage).Take(search.PageSize);

			List<Rushing> rushingList = await filterQuery.ToListAsync();

			RushingDTO returnList = new RushingDTO()
			{
				Rushings = rushingList,
				TotalCount = totalCount
			};

			return returnList;
		}

		public async Task<RushingDTO> PostRushings()
		{
			int tableCount = await _dataContext.Rushings.CountAsync();
			if(tableCount == 0)
			{
				string path = Directory.GetCurrentDirectory() + _config.GetValue<string>(Constants.RushingFileRelative);
				List<Rushing> rushingJSON = JsonConvert.DeserializeObject<List<Rushing>>(File.ReadAllText(path)) ?? new List<Rushing>();
				if(rushingJSON.Count > 0)
				{
					foreach(Rushing element in rushingJSON)
					{
						if(element.Lng.Contains("T"))
						{
							element.LngDistance = Int32.Parse(element.Lng.Replace("T", String.Empty));
						}
						else
						{
							element.LngDistance = Int32.Parse(element.Lng);
						}
					}

					_dataContext.Rushings.AddRange(rushingJSON);
					await _dataContext.SaveChangesAsync();
					return await GetRushings(new RushingSearch { Player = "", SortValue = "", SortDirection = "", CurrentPage = 0, PageSize = 25 }); ;
				}
				
			}
			
			return new RushingDTO();
		}
	}
}
