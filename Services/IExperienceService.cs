using BenDavisWebsite.Models;

namespace BenDavisWebsite.Services
{
	public interface IExperienceService
	{
		public Task<List<Experience>> GetExperienceList();
		public Task AddExperience(Experience experience, MemoryStream? imageStream = null);
		public List<Experience> SortExperienceList(List<Experience>? experienceList, List<string> identifiers);
		public Task<List<string>> GetSkills();
	}
}
