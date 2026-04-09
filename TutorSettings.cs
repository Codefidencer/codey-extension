using System;

namespace Codey.Extension
{
    /// <summary>
    /// Static bridge so CodeyControl can reach package-level services
    /// without a hard dependency on AsyncPackage.
    /// </summary>
    internal static class TutorSettings
    {
        public static Func<string> OllamaModelProvider    { get; set; } = () => "qwen2.5-coder:1.5b";
        public static Func<string> OllamaEndpointProvider { get; set; } = () => "http://localhost:11434";
        public static Action       ShowOptions             { get; set; } = () => { };
    }
}
