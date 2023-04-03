using System.Windows;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

namespace IXRay.Shell.Wpf.ViewModels;

public class CommonViewModel : ObservableObject {
    private string? _filePath;

    private IRelayCommand<object>? _previewDragOverCommand;
    private IRelayCommand<object>? _dropCommand;

    public string? FilePath {
        get => _filePath;
        set => SetProperty(ref _filePath, value);
    }

    public IRelayCommand<object> PreviewDragOverCommand => _previewDragOverCommand ??= new RelayCommand<object>(
        param => PreviewDragOverFile(param as DragEventArgs),
        param => true);

    public IRelayCommand<object> DropCommand => _dropCommand ??= new RelayCommand<object>(
        param => DropFile(param as DragEventArgs),
        param => true);

    private void PreviewDragOverFile(DragEventArgs? e) {
        if (e != null) {
            e.Handled = true;
        }
    }

    private void DropFile(DragEventArgs? e) {
        if (e!.Data.GetDataPresent(DataFormats.FileDrop)) {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            FilePath = files[0];
        }
    }
}
