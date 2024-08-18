using ContactUsApi.Models;
using System.Text.Json;

namespace ContactUsApi.Services
{
    public class ContactService
    {
        private readonly string _dataDirectory = "Data";

        public ContactService()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        public async Task<List<ContactSubmission>> GetAsync()
        {
            var submissions = new List<ContactSubmission>();
            var files = Directory.GetFiles(_dataDirectory, "*.json");

            foreach (var file in files)
            {
                var json = await File.ReadAllTextAsync(file);
                var submission = JsonSerializer.Deserialize<ContactSubmission>(json);
                if (submission != null)
                {
                    submissions.Add(submission);
                }
            }

            return submissions;
        }

        public async Task<ContactSubmission?> GetAsync(string id)
        {
            var filePath = Path.Combine(_dataDirectory, $"{id}.json");
            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<ContactSubmission>(json);
            }

            return null;
        }

        public async Task CreateAsync(ContactSubmission newSubmission)
        {
            var filePath = Path.Combine(_dataDirectory, $"{newSubmission.Id}.json");
            var json = JsonSerializer.Serialize(newSubmission);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async Task UpdateAsync(string id, ContactSubmission updatedSubmission)
        {
            var filePath = Path.Combine(_dataDirectory, $"{id}.json");
            if (File.Exists(filePath))
            {
                var json = JsonSerializer.Serialize(updatedSubmission);
                await File.WriteAllTextAsync(filePath, json);
            }
        }

        public async Task RemoveAsync(string id)
        {
            var filePath = Path.Combine(_dataDirectory, $"{id}.json");
            if (File.Exists(filePath))
            {
                File.Delete(filePath); 
            }
        }
    }
}
