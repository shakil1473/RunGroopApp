using System;
using Microsoft.EntityFrameworkCore;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;

namespace RunGroop.Repository
{
	public class RaceRepository : IRaceInterface
	{
        private readonly ApplicationDbContext _applicationDbContext;
		public RaceRepository(ApplicationDbContext applicationDbContext)
		{
            _applicationDbContext = applicationDbContext;
		}

        public bool Add(Race race)
        {
            _applicationDbContext.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            _applicationDbContext.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await _applicationDbContext.Races.ToListAsync();
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Races.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Race> GetByIdAsyncNoTracking(int id)
        {
            return await _applicationDbContext.Races.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<IEnumerable<Race>> GetClubsByCity(string city)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _applicationDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            _applicationDbContext.Update(race);
            return Save();
        }
    }
}

