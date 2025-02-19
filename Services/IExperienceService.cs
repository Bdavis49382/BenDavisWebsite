using BenDavisWebsite.Models;

namespace BenDavisWebsite.Services
{
	public interface IExperienceService
	{
		public Task<List<Experience>> GetExperienceList();
		public Task AddExperience(Experience experience);
		public List<Experience> SortExperienceList(List<Experience>? experienceList, List<string> identifiers);
	}
}
