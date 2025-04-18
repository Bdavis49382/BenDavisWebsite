using BenDavisWebsite.Models;
namespace BenDavisWebsite.Database
{
    public interface IExperienceDB
    {

        public Task AddExperience(Experience e, MemoryStream? imageStream);
        public Task<List<Experience>> GetExperiencesAsync();
        public Task<List<string>> GetSkills();
    }
}
