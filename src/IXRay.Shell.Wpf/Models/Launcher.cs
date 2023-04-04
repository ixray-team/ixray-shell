using System.Diagnostics;

using Microsoft.Win32;

using Ookii.Dialogs.Wpf;

namespace IXRay.Shell.Wpf.Models;

public static class Launcher {
    public static string? GetExecutablePath(string filter, string? oldPath = null) {
        var openDialog = new OpenFileDialog {
            Filter = filter,
        };
        var dialogResult = openDialog.ShowDialog() ?? false;
        if (dialogResult) {
            return openDialog.FileName;
        }
        return oldPath;
    }

    public static string? GetFolderPath(string? oldPath = null) {
        var openDialog = new VistaFolderBrowserDialog();
        var dialogResult = openDialog.ShowDialog() ?? false;
        if (dialogResult) {
            return openDialog.SelectedPath;
        }
        return oldPath;
    }

    public static void Launch(string? path, string? workingDirectory = null,
        IList<string> arguments = null!) {
        if (string.IsNullOrEmpty(path)) {
            return;
        }

        var process = new Process {
            StartInfo = new ProcessStartInfo {
                FileName = path,
                Arguments = arguments != null
                    ? string.Join(" ", arguments)
                    : string.Empty,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                CreateNoWindow = true,
            },
        };
        process.Start();
    }
}
