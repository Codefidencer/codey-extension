using System.Collections.Generic;

namespace Codey.Extension.Models
{
    public class UserProgress
    {
        public HashSet<string>      CompletedExercises { get; set; } = new HashSet<string>();
        public Dictionary<string, int> HintCounts      { get; set; } = new Dictionary<string, int>();

        public bool IsCompleted(string title)    => CompletedExercises.Contains(title);
        public void MarkCompleted(string title)  => CompletedExercises.Add(title);
        public void UnmarkCompleted(string title)=> CompletedExercises.Remove(title);

        public int GetHintCount(string title)
        {
            HintCounts.TryGetValue(title, out int n);
            return n;
        }

        public void IncrementHintCount(string title)
        {
            HintCounts.TryGetValue(title, out int n);
            HintCounts[title] = n + 1;
        }
    }
}
