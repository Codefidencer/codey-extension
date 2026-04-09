using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;

namespace Codey.Extension.ToolWindows
{
    [Guid("46D0EDDF-07F4-45A8-96BF-283B4C49E3F7")]
    public class CodeyToolWindow : ToolWindowPane
    {
        public CodeyToolWindow() : base(null)
        {
            this.Caption = "Codey Tutor";
            this.Content = new CodeyControl();
        }
    }
}
