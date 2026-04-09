using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace Codey.Extension.ToolWindows
{
    internal sealed class OpenCodeyCommand
    {
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("E679893A-634C-4BFC-A5C5-915CB40F8FB7");

        private readonly AsyncPackage _package;

        private OpenCodeyCommand(AsyncPackage package, OleMenuCommandService commandService)
        {
            _package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(Execute, menuCommandID);
            commandService.AddCommand(menuItem);
        }

        public static async Task InitializeAsync(AsyncPackage package)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync(package.DisposalToken);
            OleMenuCommandService commandService = await package.GetServiceAsync(typeof(IMenuCommandService)) as OleMenuCommandService;
            new OpenCodeyCommand(package, commandService);
        }

        private void Execute(object sender, EventArgs e)
        {
            _ = _package.JoinableTaskFactory.RunAsync(async () =>
            {
                ToolWindowPane window = await _package.ShowToolWindowAsync(
                    typeof(CodeyToolWindow),
                    0,
                    create: true,
                    cancellationToken: _package.DisposalToken);
            });
        }
    }
}
