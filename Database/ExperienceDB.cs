using BenDavisWebsite.Models;
using Google.Cloud.Firestore;
using Firebase.Storage;
namespace BenDavisWebsite.Database
{
    public class ExperienceDB : IExperienceDB
    {
        private readonly FirestoreDb _db;
        private readonly FirebaseStorage _firebaseStorage;

        public ExperienceDB()
        {
            _db = FirestoreDb.Create("portfolio-d9972");
            _firebaseStorage = new FirebaseStorage("portfolio-d9972.appspot.com");
        }

        public async Task AddExperience(Experience e, MemoryStream? imageStream)
        {
            if (imageStream != null)
            {
                string tempPath = Path.GetTempFileName();
                using (FileStream filestream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                {
                    imageStream.WriteTo(filestream);
                }
                var imageFileStream = File.Open(tempPath, FileMode.Open);
				var imageUrl = await _firebaseStorage.Child(e.MediaLink).PutAsync(imageFileStream);
				e.MediaLink = imageUrl;
                // Cleanup
                imageFileStream.Close();
                File.Delete(tempPath);
            }
            var response = await _db.Collection("Experiences").AddAsync(e);
        }

        public async Task<List<Experience>> GetExperiencesAsync()
        {
            List<Experience> outList = new();
            var response = await _db.Collection("Experiences").GetSnapshotAsync();
            foreach (DocumentSnapshot snapshot in response)
            {
                outList.Add(new Experience
                {
                    Name = snapshot.GetValue<string>("Name"),
                    Technologies = snapshot.GetValue<List<string>>("Technologies"),
                    Skills = snapshot.GetValue<List<string>>("Skills"),
                    Links = snapshot.GetValue<List<string[]>>("Links"),
                    Description = snapshot.GetValue<string>("Description"),
                    Type = snapshot.GetValue<ExperienceType>("Type"),
                    MediaLink = snapshot.GetValue<string>("MediaLink"),
                    Media = snapshot.GetValue<MediaType>("Media"),
                    Started = snapshot.GetValue<DateTime>("Started"),
                    Finished = snapshot.GetValue<DateTime>("Finished")
                });
            }
            return outList;
        }
    }
}
