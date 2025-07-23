using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Boitoan.BLL
{
    public class GeminiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string Model = "models/gemini-2.0-flash-lite";

        public GeminiService(IHttpClientFactory factory, IConfiguration configuration)
        {
            _httpClient = factory.CreateClient();
            _apiKey = configuration["Gemini:ApiKey"] ?? throw new Exception("Gemini API key missing");
        }

        public async Task<string> GenerateDescriptionAsync(string type, string resultCode)
        {
            var prompt = $"Hãy mô tả chi tiết kết quả {type} với mã {resultCode} theo phong cách thân thiện, dễ hiểu và ngắn gọn cho người dùng Việt Nam. Tập trung vào điểm mạnh, phong cách làm việc và định hướng nghề nghiệp.";

            var request = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var url = $"https://generativelanguage.googleapis.com/v1beta/{Model}:generateContent?key={_apiKey}";
            var response = await _httpClient.PostAsJsonAsync(url, request);
            var responseString = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Gemini API failed: {responseString}");

            try
            {
                using var doc = JsonDocument.Parse(responseString);
                return doc.RootElement
                          .GetProperty("candidates")[0]
                          .GetProperty("content")
                          .GetProperty("parts")[0]
                          .GetProperty("text")
                          .GetString()
                       ?? "Không thể tạo mô tả.";
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to parse Gemini API response: " + ex.Message);
            }
        }
    }
}
