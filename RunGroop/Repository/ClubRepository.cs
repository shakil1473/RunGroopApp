using System;
using Microsoft.EntityFrameworkCore;
using RunGroop.Data;
using RunGroop.Interface;
using RunGroop.Models;

namespace RunGroop.Repository
{
    public class ClubRepository : IClubInterface
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ClubRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public bool Add(Club club)
        {
            _applicationDbContext.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            _applicationDbContext.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await _applicationDbContext.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Clubs.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<IEnumerable<Club>> GetClubsByCity(string city)
        {
            // return await _applicationDbContext.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _applicationDbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Club club)
        {
            _applicationDbContext.Update(club);
            return Save();
        }
    }
}

