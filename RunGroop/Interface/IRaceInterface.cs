using System;
using RunGroop.Models;

namespace RunGroop.Interface
{
	public interface IRaceInterface
	{
        Task<IEnumerable<Race>> GetAll();
        Task<Race> GetByIdAsync(int id);
        Task<Race> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Race>> GetClubsByCity(string city);
        bool Add(Race race);
        bool Update(Race race);
        bool Delete(Race race);
        bool Save();
    }
}

