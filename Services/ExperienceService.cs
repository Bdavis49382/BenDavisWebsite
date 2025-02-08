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
			Links=new() {("Github","https://github.com"), ("Website", "website.com")}
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

		public List<Experience> GetExperienceList()
		{ 
			return _experienceDB; 
		}

	}
}
