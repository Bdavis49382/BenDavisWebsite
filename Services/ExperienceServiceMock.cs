using BenDavisWebsite.Models;

namespace BenDavisWebsite.Services
{
	public class ExperienceServiceMock : IExperienceService
	{
		List<Experience> _experienceDB = new() { 
			new() {
			Description="A project where I...", 
			Name="Fake Project", 
			Type=ExperienceType.PersonalProject,
			Technologies=new() {"Python", "Pygame"},
			Skills=new() {"Troubleshooting", "Leadership"},
			//Links=new() { new string[2] { "Github", "https://github.com" }, new string[2] {"Website", "website.com"}}
			},
			new() {
			Description="A project where I...", 
			Name="Fake Project", 
			Type=ExperienceType.PersonalProject,
			Technologies=new() {"Python", "Pygame"},
			Skills=new() {"Troubleshooting", "Leadership"}
			}
		};

		public async Task<List<Experience>> GetExperienceList()
		{ 
			return _experienceDB; 
		}

		public async Task AddExperience(Experience experience, MemoryStream? imageStream = null)
		{
			_experienceDB.Add(Clean(experience));
		}

		public Experience Clean(Experience experience)
		{
			foreach (Link link in experience.Links)
			{
				if (string.IsNullOrEmpty(link.Text))
				{
					link.Text = "Link";
				}

				if (string.IsNullOrEmpty(link.Url))
				{
					link.Text = "Empty Link";
				}

				if (!link.Url.Contains("https://"))
				{
					link.Url = "https://" + link.Url;
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
		public async Task<List<string>> GetSkills()
		{
			return new List<string>();
		}

	}
}
