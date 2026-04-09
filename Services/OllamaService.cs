using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Codey.Extension.Services
{
    public class OllamaService
    {
        private static readonly HttpClient _http = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };

        private const string DefaultModel    = "qwen2.5-coder:7b";
        private const string DefaultEndpoint = "http://localhost:11434";

        private string Model    => TutorSettings.OllamaModelProvider?.Invoke()    ?? DefaultModel;
        private string Endpoint => TutorSettings.OllamaEndpointProvider?.Invoke() ?? DefaultEndpoint;

        public async Task<string> GetHintAsync(
            string exerciseTitle,
            string exerciseDescription,
            string currentCode)
        {
            string prompt =
                "You are Codey, a C# tutor. Give a HINT only — never the solution.\n" +
                "RULES: No C# code. No backticks. No complete answers. Max 2 sentences.\n" +
                "Ask a guiding question or name the concept the student should look up.\n\n" +
                $"Exercise: {exerciseTitle}\n" +
                $"Goal: {exerciseDescription}\n" +
                $"Student code:\n{currentCode}\n\n" +
                "Hint (2 sentences max, plain English, NO code):";

            return await GenerateAsync(prompt);
        }

        public async Task<string> GetLiveReviewAsync(
            string exerciseTitle,
            string exerciseDescription,
            string currentCode)
        {
            string prompt =
                "You are Codey, a C# tutor giving live feedback. " +
                "In 1-3 plain English sentences: note what looks good, what is missing, or what to try next. " +
                "Do NOT write code. Do NOT use code blocks. Do NOT give the solution. Be concise and encouraging.\n\n" +
                $"Exercise: {exerciseTitle}\n" +
                $"Goal: {exerciseDescription}\n\n" +
                $"Code:\n{currentCode}\n\n" +
                "Brief feedback (plain English, no code):";

            return await GenerateAsync(prompt);
        }

        private async Task<string> GenerateAsync(string prompt)
        {
            string url = Endpoint.TrimEnd('/') + "/api/generate";

            string reqJson =
                "{" +
                $"\"model\":\"{EscapeJson(Model)}\"," +
                $"\"prompt\":\"{EscapeJson(prompt)}\"," +
                "\"stream\":false" +
                "}";

            try
            {
                using (var req = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    req.Content = new StringContent(reqJson, Encoding.UTF8, "application/json");
                    HttpResponseMessage resp = await _http.SendAsync(req);
                    string body = await resp.Content.ReadAsStringAsync();

                    if (!resp.IsSuccessStatusCode)
                        return $"Ollama error {(int)resp.StatusCode}. Make sure Ollama is running: ollama serve";

                    return ParseResponse(body);
                }
            }
            catch (HttpRequestException)
            {
                return "Could not reach Ollama. Make sure it is running:\n  ollama serve\n\nAnd the model is pulled:\n  ollama pull " + Model;
            }
            catch (TaskCanceledException)
            {
                return "Ollama timed out. The model may still be loading \u2014 try again in a moment.";
            }
        }

        // ── JSON helpers ────────────────────────────────────────────────────────

        private string ParseResponse(string json)
        {
            int idx = json.IndexOf("\"response\":\"");
            if (idx < 0) return "Could not parse Ollama response.";
            int start = idx + 12;
            int end   = FindStringEnd(json, start);
            if (end < 0) return json;
            return UnescapeJson(json.Substring(start, end - start)).Trim();
        }

        private static int FindStringEnd(string s, int start)
        {
            for (int i = start; i < s.Length; i++)
            {
                if (s[i] == '\\') { i++; continue; }
                if (s[i] == '"')  return i;
            }
            return -1;
        }

        private static string EscapeJson(string s) => s
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\n", "\\n")
            .Replace("\r", "")
            .Replace("\t", "\\t");

        private static string UnescapeJson(string s) => s
            .Replace("\\n",  "\n")
            .Replace("\\t",  "\t")
            .Replace("\\\"", "\"")
            .Replace("\\\\", "\\");
    }
}
