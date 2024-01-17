using System;
using RunGroop.Models;

namespace RunGroop.Interface
{
	public interface IClubInterface
	{
		Task<IEnumerable<Club>> GetAll();
		Task<Club> GetByIdAsync(int id);
		Task<Club> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Club>> GetClubsByCity(string city);
		bool Add(Club club);
		bool Update(Club club);
		bool Delete(Club club);
		bool Save();
	}
}

