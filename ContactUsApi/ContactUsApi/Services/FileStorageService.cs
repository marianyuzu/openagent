using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ContactUsApi.Models;

namespace ContactUsApi.Services
{
    public class FileStorageService
    {
        private readonly string _filePath;

        public FileStorageService()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "submissions.json");

            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        public async Task SaveSubmissionAsync(ContactSubmission submission)
        {
            var submissions = await GetAllSubmissionsAsync();

            submissions.Add(submission);

            var json = JsonSerializer.Serialize(submissions, new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<List<ContactSubmission>> GetAllSubmissionsAsync()
        {
            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<ContactSubmission>>(json) ?? new List<ContactSubmission>();
        }
    }
}
