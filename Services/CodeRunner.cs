using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Codey.Extension.Services
{
    public class CodeRunner
    {
        public async Task<string> RunAsync(string code)
        {
            string tmpDir  = Path.Combine(Path.GetTempPath(), "CodeyRun_" + Guid.NewGuid().ToString("N"));
            string srcFile = Path.Combine(tmpDir, "Program.cs");
            string exeFile = Path.Combine(tmpDir, "Program.exe");
            string csc     = FindRoslynCsc();

            Directory.CreateDirectory(tmpDir);
            File.WriteAllText(srcFile, code);

            try
            {
                // /langversion:latest enables async Task Main and all modern C# features
                string compileArgs = IsRoslyn(csc)
                    ? $"/langversion:latest /out:\"{exeFile}\" \"{srcFile}\""
                    : $"/out:\"{exeFile}\" \"{srcFile}\"";

                string compileOut = await RunProcessAsync(csc, compileArgs);
                if (!File.Exists(exeFile))
                    return "Compile error:\n" + compileOut;

                string runOut = await RunProcessAsync(exeFile, "");
                return string.IsNullOrWhiteSpace(runOut) ? "(no output)" : runOut;
            }
            finally
            {
                try { Directory.Delete(tmpDir, true); } catch { }
            }
        }

        private static string FindRoslynCsc()
        {
            // Prefer Roslyn csc (ships with VS, supports all modern C# features)
            string[] editions = { "Enterprise", "Professional", "Community", "BuildTools", "Preview" };
            string[] years    = { "2022", "2019" };
            foreach (var year in years)
                foreach (var edition in editions)
                {
                    string path = $@"C:\Program Files\Microsoft Visual Studio\{year}\{edition}\MSBuild\Current\Bin\Roslyn\csc.exe";
                    if (File.Exists(path)) return path;
                }

            // Fall back to old Framework csc
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                @"Microsoft.NET\Framework64\v4.0.30319\csc.exe");
        }

        private static bool IsRoslyn(string cscPath)
            => cscPath.IndexOf("Roslyn", StringComparison.OrdinalIgnoreCase) >= 0;

        private static Task<string> RunProcessAsync(string exe, string args)
        {
            return Task.Run(() =>
            {
                var psi = new ProcessStartInfo(exe, args)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError  = true,
                    UseShellExecute        = false,
                    CreateNoWindow         = true
                };
                using (var p = Process.Start(psi))
                {
                    // Read stdout and stderr concurrently to prevent deadlock when buffers fill
                    var stdoutTask = Task.Run(() => p.StandardOutput.ReadToEnd());
                    var stderrTask = Task.Run(() => p.StandardError.ReadToEnd());
                    p.WaitForExit();
                    string stdout = stdoutTask.Result;
                    string stderr = stderrTask.Result;
                    return string.IsNullOrWhiteSpace(stderr) ? stdout : stdout + "\n" + stderr;
                }
            });
        }
    }
}
