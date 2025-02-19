using BenDavisWebsite.Models;

namespace BenDavisWebsite.Services
{
	public class ExperienceService : IExperienceService
	{
		List<Experience> _experienceDB = new() { 
			new() {
			Description="A project where I...", 
			Name="Fake Project", 
			Type=ExperienceType.PersonalProject,
			Technologies=new() {"Python", "Pygame"},
			Skills=new() {"Troubleshooting", "Leadership"},
			Links=new() { new string[2] { "Github", "https://github.com" }, new string[2] {"Website", "website.com"}}
			},
			new() {
			Description="A project where I...", 
			Name="Fake Project", 
			Type=ExperienceType.PersonalProject,
			Technologies=new() {"Python", "Pygame"},
			Skills=new() {"Troubleshooting", "Leadership"}
			}
		};

		//public ExperienceService(List<Experience> experienceDB)
		//{
		//	_experienceDB = experienceDB;
		//}

		public async Task<List<Experience>> GetExperienceList()
		{ 
			return _experienceDB; 
		}

		public async Task AddExperience(Experience experience)
		{
			_experienceDB.Add(Clean(experience));
		}

		public Experience Clean(Experience experience)
		{
			foreach (string[] link in experience.Links)
			{
				if (string.IsNullOrEmpty(link[0]))
				{
					link[0] = "Link";
				}

				if (string.IsNullOrEmpty(link[1]))
				{
					link[0] = "Empty Link";
				}

				if (!link[1].Contains("https://"))
				{
					link[1] = "https://" + link[1];
				}
			}
			return experience;
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
