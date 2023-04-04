using System.IO;
using System.Windows;

namespace IXRay.Shell.Wpf.Models;

public static class DragAndDrop {
    public static void PreviewDragOverHandler(DragEventArgs? e) {
        if (e != null) {
            e.Handled = true;
        }
    }

    public static string? DropFileHander(DragEventArgs? e, string? fileName) {
        if (e!.Data.GetDataPresent(DataFormats.FileDrop)) {
            var data = (string[]) e.Data.GetData(DataFormats.FileDrop);
            var path = data[0];
            if (Path.GetFileName(path) != fileName) {
                return string.Empty;
            }
            return path;
        }
        return string.Empty;
    }

    public static string? DropFolderHander(DragEventArgs? e) {
        if (e!.Data.GetDataPresent(DataFormats.FileDrop)) {
            var data = (string[]) e.Data.GetData(DataFormats.FileDrop);
            var path = data[0];
            if (!Directory.Exists(path)) {
                return string.Empty;
            }
            return path;
        }
        return string.Empty;
    }
}
