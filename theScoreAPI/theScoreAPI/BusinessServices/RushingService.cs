using System.IO;

using Microsoft.EntityFrameworkCore;

using theScoreAPI.Context;
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
            IQueryable<Rushing> staffFacilityFilterQuery = _dataContext.Rushings;

            if (!string.IsNullOrEmpty(search.Player))
            {
                staffFacilityFilterQuery = staffFacilityFilterQuery.Where(p => p.Player.Contains(search.Player));
            }

            if (!string.IsNullOrEmpty(search.SortValue) && !string.IsNullOrEmpty(search.SortDirection))
            {
                if (search.SortValue == "yds")
                {
                    if (search.SortDirection == "asc")
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderBy(o => o.Yds);
                    }
                    else
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderByDescending(o => o.Yds);
                    }
                }
                else if (search.SortValue == "td")
                {
                    if (search.SortDirection == "asc")
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderBy(o => o.TD);
                    }
                    else
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderByDescending(o => o.TD);
                    }
                }
                else if (search.SortValue == "lng")
                {
                    if (search.SortDirection == "asc")
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderBy(o => o.LNG);
                    }
                    else
                    {
                        staffFacilityFilterQuery = staffFacilityFilterQuery.OrderByDescending(o => o.LNG);
                    }
                }
            }
           
            int totalCount = staffFacilityFilterQuery.Count();
            staffFacilityFilterQuery = staffFacilityFilterQuery.Skip(search.PageSize * search.CurrentPage).Take(search.PageSize);

            List<Rushing> rushingList = await staffFacilityFilterQuery.ToListAsync();

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
                string path = Directory.GetCurrentDirectory() + _config.GetValue<string>("RushingFileRelative");
                List<Rushing> rushingJSON = JsonConvert.DeserializeObject<List<Rushing>>(File.ReadAllText(path)) ?? new List<Rushing>();
                if(rushingJSON.Count > 0)
                {
                    _dataContext.Rushings.AddRange(rushingJSON);
                    await _dataContext.SaveChangesAsync();
                    return await GetRushings(new RushingSearch { Player = "", SortValue = "", SortDirection = "", CurrentPage = 0, PageSize = 25 }); ;
                }
                
            }
            
            return new RushingDTO();
        }
    }
}
