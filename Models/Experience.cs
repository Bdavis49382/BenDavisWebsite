using Google.Cloud.Firestore;

namespace BenDavisWebsite.Models
{
	[FirestoreData]
	public class Experience
	{
		public List<string> _technologies = new();
		[FirestoreProperty]
		public List<string> Technologies { 
			get { return _technologies; }
			set { _technologies = value; }
		}
		public List<string> _skills = new();
		[FirestoreProperty]
		public List<string> Skills
		{
			get { return _skills; }
			set { _skills = value; }
		}
		public List<Link> _links = new();
		[FirestoreProperty]
		public List<Link> Links
		{
			get { return _links; }
			set { _links = value; }
		}
		[FirestoreProperty]
		public string? Description { get; set; }
		[FirestoreProperty]
		public string? Name { get; set; }
		[FirestoreProperty]
		public ExperienceType Type { get; set; }
		[FirestoreProperty]
		public string? MediaLink { get; set; }
		[FirestoreProperty]
		public MediaType Media { get; set; }
		[FirestoreProperty]
		public DateTime Started { get; set; } = DateTime.UtcNow;
		[FirestoreProperty]
		public DateTime Finished { get; set; } = DateTime.UtcNow;
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
	[FirestoreData]
	public class Link
	{
		[FirestoreProperty]
		public string? Text { get; set; } = String.Empty;

		[FirestoreProperty]
		public string? Url { get; set; } = String.Empty;
	}
}
