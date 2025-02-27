using BenDavisWebsite.Database;
using BenDavisWebsite.Models;

namespace BenDavisWebsite.Services
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceDB  _db;

        public ExperienceService(IExperienceDB db)
        {
            _db = db;
        }

		public async Task<List<Experience>> GetExperienceList()
        {
			return await _db.GetExperiencesAsync();
        }
		public async Task AddExperience(Experience experience, MemoryStream? imageStream = null)
        {
			experience.Started = DateTime.SpecifyKind(experience.Started, DateTimeKind.Utc);
			experience.Finished = DateTime.SpecifyKind(experience.Finished, DateTimeKind.Utc);
            await _db.AddExperience(experience, imageStream);
        }
		public List<Experience> SortExperienceList(List<Experience>? experienceList, List<string> identifiers)
        {
			List<Experience> outList = new();
			foreach (string item in identifiers)
			{
				foreach (Experience experience in experienceList)
				{
					if (outList.Contains(experience)) { }
					else if (experience.Skills.Contains(item) || experience.Technologies.Contains(item))
					{
						outList.Add(experience);
					}
				}
			}
			return outList;
        }
    }
}
