using System;
using System.Collections.Generic;
using System.IO;
using Codey.Extension.Models;

namespace Codey.Extension.Services
{
    public static class ProgressService
    {
        private static readonly string FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Codey", "progress.txt");

        public static UserProgress Load()
        {
            var p = new UserProgress();
            if (!File.Exists(FilePath)) return p;
            try
            {
                foreach (string line in File.ReadAllLines(FilePath))
                {
                    if (line.StartsWith("DONE:"))
                        p.CompletedExercises.Add(line.Substring(5));
                    else if (line.StartsWith("HINTS:"))
                    {
                        int eq = line.IndexOf('=', 6);
                        if (eq > 6 && int.TryParse(line.Substring(eq + 1), out int n))
                            p.HintCounts[line.Substring(6, eq - 6)] = n;
                    }
                }
            }
            catch { }
            return p;
        }

        public static void Save(UserProgress p)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                var lines = new List<string>();
                foreach (string title in p.CompletedExercises)
                    lines.Add("DONE:" + title);
                foreach (var kv in p.HintCounts)
                    lines.Add($"HINTS:{kv.Key}={kv.Value}");
                File.WriteAllLines(FilePath, lines);
            }
            catch { }
        }
    }
}
