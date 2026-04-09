using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace Codey.Extension.Options
{
    [ComVisible(true)]
    public class TutorOptionsPage : DialogPage
    {
        [Category("Ollama AI")]
        [DisplayName("Model")]
        [Description("Ollama model for hints and live review. Recommended: qwen2.5-coder:1.5b (~1 GB RAM, fast). Pull it with: ollama pull qwen2.5-coder:1.5b")]
        public string OllamaModel { get; set; } = "qwen2.5-coder:1.5b";

        [Category("Ollama AI")]
        [DisplayName("Endpoint")]
        [Description("Ollama server URL. Default is http://localhost:11434 — change only if you run Ollama on a different host or port.")]
        public string OllamaEndpoint { get; set; } = "http://localhost:11434";
    }
}
