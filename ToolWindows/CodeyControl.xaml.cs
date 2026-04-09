using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Codey.Extension.Models;
using Codey.Extension.Services;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Codey.Extension;

namespace Codey.Extension.ToolWindows
{
    public partial class CodeyControl : UserControl
    {
        private readonly CodeRunner    _runner = new CodeRunner();
        private readonly OllamaService _ollama = new OllamaService();

        private List<Exercise> _all;
        private List<Exercise> _filtered;
        private Exercise       _current;
        private UserProgress   _progress;
        private string         _activeFilter = "All";
        private bool           _reselecting  = false;

        // Live-review state
        private string              _tempFilePath;
        private DispatcherTimer     _reviewTimer;
        private TextEditorEvents    _textEditorEvents;   // must be a field to prevent GC

        public CodeyControl()
        {
            InitializeComponent();
            _progress = ProgressService.Load();
            _all      = ExerciseRepository.GetAll();
            ApplyFilter("All");
            UpdateProgress();
            SetTutor("Select an exercise from the list to begin.\n\n" +
                     "Open in VS \uD83D\uDCC2  opens the starter code in the real VS editor.\n" +
                     "\u25B6 Run  compiles and runs your code.\n" +
                     "Hint \uD83D\uDCA1  asks the local AI for a personalised tip.\n" +
                     "Done \u2713  marks the exercise as complete.\n\n" +
                     "AI hints and live review are powered by Ollama (free, runs locally).\n" +
                     "Setup:\n" +
                     "  1. Install Ollama \u2014 https://ollama.com\n" +
                     "  2. ollama pull qwen2.5-coder:1.5b\n" +
                     "  3. ollama serve");
        }

        // ── XP system ────────────────────────────────────────────────────────

        private static int XpForExercise(Exercise ex)
            => ex.Level == "Beginner" ? 10 : ex.Level == "Intermediate" ? 25 : 50;

        private int ComputeXP()
        {
            int total = 0;
            foreach (string title in _progress.CompletedExercises)
            {
                var ex = _all.FirstOrDefault(e => e.Title == title);
                if (ex != null) total += XpForExercise(ex);
            }
            return total;
        }

        private static (string Title, int Level) GetXpLevel(int xp)
        {
            if (xp >= 1200) return ("Master",     6);
            if (xp >= 700)  return ("Engineer",   5);
            if (xp >= 350)  return ("Developer",  4);
            if (xp >= 150)  return ("Coder",      3);
            if (xp >= 50)   return ("Apprentice", 2);
            return              ("Novice",     1);
        }

        // ── Progress bar ─────────────────────────────────────────────────────

        private void UpdateProgress()
        {
            int done  = _progress.CompletedExercises.Count;
            int total = _all.Count;
            ProgressBar.Maximum = total;
            ProgressBar.Value   = done;
            ProgressText.Text   = $"{done} / {total}";

            int xp = ComputeXP();
            var (lvlTitle, lvlNum) = GetXpLevel(xp);
            XpText.Text = $"\u26A1 {xp} XP  \u2022  {lvlTitle} (Lv.{lvlNum})";
        }

        // ── Filters ──────────────────────────────────────────────────────────

        private void FilterBtn_Click(object sender, RoutedEventArgs e)
            => ApplyFilter((string)((Button)sender).Tag);

        private void ApplyFilter(string level)
        {
            _activeFilter = level;
            _filtered = level == "All"
                ? _all
                : _all.Where(x => x.Level == level).ToList();

            SetFilterActive(BtnAll,          level == "All");
            SetFilterActive(BtnBeginner,     level == "Beginner");
            SetFilterActive(BtnIntermediate, level == "Intermediate");
            SetFilterActive(BtnAdvanced,     level == "Advanced");

            RefreshExerciseList();
        }

        private static void SetFilterActive(Button btn, bool active)
        {
            btn.Background = new SolidColorBrush(active
                ? Color.FromRgb(0, 229, 255)
                : Color.FromRgb(26, 32, 48));
            btn.Foreground = new SolidColorBrush(active
                ? Color.FromRgb(0, 0, 0)
                : Color.FromRgb(85, 102, 119));
            btn.FontWeight = active ? FontWeights.SemiBold : FontWeights.Normal;
        }

        // ── Exercise list ─────────────────────────────────────────────────────

        private void RefreshExerciseList()
        {
            ExerciseList.SelectionChanged -= ExerciseList_SelectionChanged;
            ExerciseList.Items.Clear();

            foreach (var ex in _filtered)
            {
                bool   done   = _progress.IsCompleted(ex.Title);
                string prefix = done ? "\u2713" : "\u2022";

                Color titleColor = done
                    ? Color.FromRgb(0, 180, 80)
                    : ex.Level == "Beginner"     ? Color.FromRgb(130, 200, 255)
                    : ex.Level == "Intermediate" ? Color.FromRgb(255, 200, 80)
                                                 : Color.FromRgb(255, 120, 180);

                string badge = ex.Level == "Beginner"     ? "BEG"
                             : ex.Level == "Intermediate" ? "INT"
                                                          : "ADV";

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(18) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

                var pfx = new TextBlock
                {
                    Text      = prefix,
                    Foreground = new SolidColorBrush(done
                        ? Color.FromRgb(0, 180, 80)
                        : Color.FromRgb(50, 70, 90)),
                    FontSize  = 12,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetColumn(pfx, 0);

                var title = new TextBlock
                {
                    Text         = ex.Title,
                    Foreground   = new SolidColorBrush(titleColor),
                    FontSize     = 13,
                    TextTrimming = TextTrimming.CharacterEllipsis,
                    VerticalAlignment = VerticalAlignment.Center
                };
                Grid.SetColumn(title, 1);

                var badgeBorder = new Border
                {
                    Background    = new SolidColorBrush(Color.FromRgb(20, 30, 45)),
                    CornerRadius  = new CornerRadius(3),
                    Padding       = new Thickness(4, 1, 4, 1),
                    Margin        = new Thickness(4, 0, 0, 0),
                    VerticalAlignment = VerticalAlignment.Center,
                    Child         = new TextBlock
                    {
                        Text       = badge,
                        Foreground = new SolidColorBrush(Color.FromRgb(60, 90, 120)),
                        FontSize   = 10,
                        FontWeight = FontWeights.Bold
                    }
                };
                Grid.SetColumn(badgeBorder, 2);

                grid.Children.Add(pfx);
                grid.Children.Add(title);
                grid.Children.Add(badgeBorder);

                ExerciseList.Items.Add(new ListBoxItem
                {
                    Content         = grid,
                    Tag             = ex,
                    BorderThickness = new Thickness(0)
                });
            }

            ExerciseList.SelectionChanged += ExerciseList_SelectionChanged;

            if (_current != null && !_reselecting)
                RestoreSelection(_current.Title);
        }

        private void RestoreSelection(string title)
        {
            _reselecting = true;
            foreach (ListBoxItem item in ExerciseList.Items)
                if (item.Tag is Exercise ex && ex.Title == title)
                {
                    ExerciseList.SelectedItem = item;
                    break;
                }
            _reselecting = false;
        }

        private void ExerciseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ExerciseList.SelectedItem is ListBoxItem item && item.Tag is Exercise ex)
                SelectExercise(ex);
        }

        private void SelectExercise(Exercise ex)
        {
            bool same = _current?.Title == ex.Title;
            _current = ex;

            if (!same)
            {
                OutputBox.Text = "";
                _tempFilePath  = null;   // new exercise — previous temp file no longer relevant
            }

            // Task description + concept
            string concept = string.IsNullOrWhiteSpace(ex.Concept) ? "" : "\n\n\uD83D\uDCDA " + ex.Concept;
            TaskText.Text = ex.Description + concept;

            // Done button state
            bool done = _progress.IsCompleted(ex.Title);
            UpdateDoneButton(done);

            // Tutor hint
            if (!same)
            {
                int hints = _progress.GetHintCount(ex.Title);
                SetTutor(hints == 0
                    ? "Click \uD83D\uDCC2 Open in VS to load the starter code into the editor, then edit and get live AI feedback from Ollama!"
                    : $"You've used {hints} hint{(hints == 1 ? "" : "s")} on this exercise. Keep trying \u2014 you've got this!");
            }
        }

        // ── Open in VS Editor ─────────────────────────────────────────────────

        private void OpenInEditorBtn_Click(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (_current == null) { SetTutor("Select an exercise first."); return; }

            try
            {
                string tempDir  = Path.Combine(Path.GetTempPath(), "CodeyTutor");
                string safeName = string.Concat(_current.Title.Split(Path.GetInvalidFileNameChars())).Replace(" ", "_");
                string projDir  = Path.Combine(tempDir, safeName);
                Directory.CreateDirectory(projDir);

                _tempFilePath     = Path.Combine(projDir, "Program.cs");
                string csprojPath = Path.Combine(projDir, safeName + ".csproj");

                // Only write starter code if the file doesn't exist yet (preserve user edits)
                if (!File.Exists(_tempFilePath))
                    File.WriteAllText(_tempFilePath, _current.StarterCode ?? "");

                // Create a minimal SDK-style console project so the user can F5 inside VS
                if (!File.Exists(csprojPath))
                    File.WriteAllText(csprojPath,
                        "<Project Sdk=\"Microsoft.NET.Sdk\">\n" +
                        "  <PropertyGroup>\n" +
                        "    <OutputType>Exe</OutputType>\n" +
                        "    <TargetFramework>net8.0</TargetFramework>\n" +
                        "    <Nullable>disable</Nullable>\n" +
                        "    <ImplicitUsings>disable</ImplicitUsings>\n" +
                        "  </PropertyGroup>\n" +
                        "</Project>\n");

                var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                if (dte == null) { SetTutor("Could not access Visual Studio editor."); return; }

                // Add the exercise as a proper project in the current solution
                try
                {
                    bool alreadyInSolution = false;
                    foreach (Project p in dte.Solution.Projects)
                        if (string.Equals(p.FileName, csprojPath, StringComparison.OrdinalIgnoreCase))
                        { alreadyInSolution = true; break; }

                    if (!alreadyInSolution)
                        dte.Solution.AddFromFile(csprojPath);
                }
                catch { /* no solution open — file-only open is fine */ }

                dte.ItemOperations.OpenFile(_tempFilePath);
                EnsureLiveReviewSubscribed(dte);

                SetTutor("\uD83D\uDCC2 Exercise project added to your solution!\n\n" +
                         "Right-click the project in Solution Explorer \u2192 \"Set as Startup Project\", then press F5 to run.\n\n" +
                         "Or press \u25BA Run in Codey (save with Ctrl+S first).");
            }
            catch (Exception ex)
            {
                SetTutor("\u26A0\uFE0F Could not open file: " + ex.Message);
            }
        }

        // ── Live review ───────────────────────────────────────────────────────

        private void EnsureLiveReviewSubscribed(DTE dte)
        {
            if (_textEditorEvents != null) return;   // already subscribed

            _textEditorEvents = dte.Events.TextEditorEvents;
            _textEditorEvents.LineChanged += OnEditorLineChanged;

            _reviewTimer          = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            _reviewTimer.Tick    += OnReviewTimerTick;
        }

        private void OnEditorLineChanged(TextPoint startPoint, TextPoint endPoint, int hint)
        {
            // Only trigger when the changed file is our current exercise temp file
            try
            {
                string changedFile = startPoint.Parent.Parent.FullName;
                if (!string.Equals(changedFile, _tempFilePath, StringComparison.OrdinalIgnoreCase))
                    return;
            }
            catch { return; }

            // Reset debounce timer
            _reviewTimer.Stop();
            _reviewTimer.Start();
        }

        private async void OnReviewTimerTick(object sender, EventArgs e)
        {
            _reviewTimer.Stop();

            if (_current == null || _tempFilePath == null || !File.Exists(_tempFilePath))
                return;

            SetTutor("\uD83D\uDC41 Reviewing your code...");

            try
            {
                string code   = File.ReadAllText(_tempFilePath);
                string review = await _ollama.GetLiveReviewAsync(
                    _current.Title, _current.Description, code);

                if (!string.IsNullOrWhiteSpace(review))
                    SetTutor("\uD83D\uDC41 " + review);
            }
            catch (Exception ex)
            {
                SetTutor("\u26A0\uFE0F Live review error: " + ex.Message);
            }
        }

        // ── Run ───────────────────────────────────────────────────────────────

        private async void RunBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_current == null) { SetTutor("Select an exercise first."); return; }

            // Read code from the VS editor temp file if available
            string code;
            if (!string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath))
            {
                // Save the active document so the file on disk reflects the latest edits
                try
                {
                    var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                    dte?.ActiveDocument?.Save();
                }
                catch { }

                code = File.ReadAllText(_tempFilePath);
            }
            else
            {
                SetTutor("\uD83D\uDCC2 Click \"Open in VS\" first to load the exercise into the editor, then run it.");
                return;
            }

            BtnRun.IsEnabled = false;
            OutputBox.Text   = "\u23F3 Compiling...";

            try
            {
                string output = await _runner.RunAsync(code);
                OutputBox.Text = output;

                if (!string.IsNullOrWhiteSpace(_current.ExpectedOutput))
                {
                    string expected = _current.ExpectedOutput
                        .Replace("\\n", "\n").Replace("...", "");
                    if (output.Trim().StartsWith(expected.Trim().Split('\n')[0]))
                        SetTutor("\u2705 Output looks correct! Click \u2713 Done to mark this exercise as complete.");
                }
            }
            catch (Exception ex) { OutputBox.Text = "Error: " + ex.Message; }
            finally { BtnRun.IsEnabled = true; }
        }

        // ── Hint ─────────────────────────────────────────────────────────────

        private async void HintBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_current == null) { SetTutor("Select an exercise first."); return; }

            // Use code from temp file if available, otherwise use starter code
            string code = (!string.IsNullOrEmpty(_tempFilePath) && File.Exists(_tempFilePath))
                ? File.ReadAllText(_tempFilePath)
                : (_current.StarterCode ?? "");

            BtnHint.IsEnabled = false;

            try
            {
                int hintIdx = _progress.GetHintCount(_current.Title);
                string hint;

                // Use static hints first; ask Ollama only when they're exhausted
                if (_current.Hints != null && hintIdx < _current.Hints.Length)
                {
                    hint = $"Hint {hintIdx + 1} of {_current.Hints.Length}: {_current.Hints[hintIdx]}";
                }
                else
                {
                    SetTutor("\uD83E\uDD14 Thinking...");
                    hint = await _ollama.GetHintAsync(_current.Title, _current.Description, code);
                }

                _progress.IncrementHintCount(_current.Title);
                ProgressService.Save(_progress);
                SetTutor("\uD83D\uDCA1 " + hint);
            }
            catch (Exception ex)
            {
                SetTutor("\u26A0\uFE0F Could not get hint: " + ex.Message);
            }
            finally { BtnHint.IsEnabled = true; }
        }

        // ── Solution ─────────────────────────────────────────────────────────

        private void SolutionBtn_Click(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (_current == null) return;

            if (string.IsNullOrWhiteSpace(_current.Solution))
            {
                SetTutor("No solution available for this exercise yet.");
                return;
            }

            var result = MessageBox.Show(
                "This will replace the exercise file with the solution.\n\nAre you sure?",
                "Show Solution",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            try
            {
                // Ensure temp file exists
                if (string.IsNullOrEmpty(_tempFilePath))
                {
                    string tempDir = Path.Combine(Path.GetTempPath(), "CodeyTutor");
                    Directory.CreateDirectory(tempDir);
                    string safeName = string.Concat(_current.Title.Split(Path.GetInvalidFileNameChars()));
                    _tempFilePath   = Path.Combine(tempDir, safeName.Replace(" ", "_") + ".cs");
                }

                File.WriteAllText(_tempFilePath, _current.Solution);

                // Open / refresh in VS
                var dte = Package.GetGlobalService(typeof(DTE)) as DTE;
                if (dte != null)
                {
                    EnsureLiveReviewSubscribed(dte);
                    dte.ItemOperations.OpenFile(_tempFilePath);
                }

                SetTutor("\uD83D\uDC41 Solution loaded in VS editor. Study it carefully, then try writing it from memory!");
            }
            catch (Exception ex)
            {
                SetTutor("\u26A0\uFE0F Could not open solution: " + ex.Message);
            }
        }

        // ── Done ─────────────────────────────────────────────────────────────

        private void DoneBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_current == null) return;

            bool wasDone = _progress.IsCompleted(_current.Title);
            if (wasDone)
                _progress.UnmarkCompleted(_current.Title);
            else
                _progress.MarkCompleted(_current.Title);

            ProgressService.Save(_progress);
            UpdateProgress();
            UpdateDoneButton(!wasDone);
            RefreshExerciseList();

            if (wasDone)
            {
                SetTutor("Unmarked. Come back whenever you want to revisit this one.");
            }
            else
            {
                int gained = XpForExercise(_current);
                int totalXp = ComputeXP();
                var (lvlTitle, lvlNum) = GetXpLevel(totalXp);
                SetTutor($"\uD83C\uDF89 Great work! Exercise marked as complete.\n\n" +
                         $"\u26A1 +{gained} XP earned!\n" +
                         $"Total: {totalXp} XP  \u2022  {lvlTitle} (Lv.{lvlNum})");
            }
        }

        private void UpdateDoneButton(bool done)
        {
            BtnDone.Content    = done ? "\u2713 Completed" : "\u2713 Done";
            BtnDone.Background = new SolidColorBrush(done
                ? Color.FromRgb(20, 60, 20)
                : Color.FromRgb(26, 42, 26));
            BtnDone.Foreground = new SolidColorBrush(done
                ? Color.FromRgb(0, 200, 80)
                : Color.FromRgb(100, 150, 100));
        }

        // ── Settings ─────────────────────────────────────────────────────────

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            TutorSettings.ShowOptions();
        }

        // ── Helpers ───────────────────────────────────────────────────────────

        private void SetTutor(string text) => TutorText.Text = text;
    }
}
