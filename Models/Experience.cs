namespace BenDavisWebsite.Models
{
	public class Experience
	{
		public List<string> Technologies = new();
		public List<string> Skills = new();
		public List<string[]> Links = new();
		public string? Description { get; set; }
		public string? Name { get; set; }
		public ExperienceType Type { get; set; }
		public string? MediaLink { get; set; }
		public MediaType Media { get; set; }
		public DateTime Started { get; set; } = DateTime.Now;
		public DateTime Finished { get; set; } = DateTime.Now;
		public string GetTypeString()
		{
			return Type switch
			{
				ExperienceType.SchoolProject => "School Project",
				ExperienceType.PersonalProject => "Personal Project",
				ExperienceType.Class => "Class",
				ExperienceType.Employment => "Employment",
				_ => "Unknown"
			};
		}

	}

	public enum ExperienceType
	{
		SchoolProject, PersonalProject, Class, Employment
	}

	public enum MediaType
	{
		 NotProvided, Image, Video	
	}
}
