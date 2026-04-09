using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace Codey.Extension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(PackageGuidString)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ToolWindows.CodeyToolWindow),
        Style = VsDockStyle.Tabbed,
        Window = ToolWindowGuids.SolutionExplorer,
        Orientation = ToolWindowOrientation.Right)]
    [ProvideAutoLoad(UIContextGuids80.NoSolution,     PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideAutoLoad(UIContextGuids80.SolutionExists, PackageAutoLoadFlags.BackgroundLoad)]
    [ProvideOptionPage(typeof(Options.TutorOptionsPage), "Codey Tutor", "Settings", 0, 0, true)]
    public sealed class CodeyPackage : AsyncPackage
    {
        public const string PackageGuidString = "51948C3C-9141-4F94-B4B9-7D8FBBC5145E";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await ToolWindows.OpenCodeyCommand.InitializeAsync(this);

            // Wire up static bridge so CodeyControl can access Ollama settings
            TutorSettings.OllamaModelProvider    = () => GetOllamaPage()?.OllamaModel    ?? "qwen2.5-coder:1.5b";
            TutorSettings.OllamaEndpointProvider = () => GetOllamaPage()?.OllamaEndpoint ?? "http://localhost:11434";
            TutorSettings.ShowOptions            = () => ShowOptionPage(typeof(Options.TutorOptionsPage));
        }

        private Options.TutorOptionsPage GetOllamaPage()
            => GetDialogPage(typeof(Options.TutorOptionsPage)) as Options.TutorOptionsPage;
    }
}
