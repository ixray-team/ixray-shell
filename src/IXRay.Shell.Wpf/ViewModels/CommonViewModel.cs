using System.Windows;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

using IXRay.Shell.Wpf.Models;

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

    private EngineInstances _instances;

    public CommonViewModel() {
        _instances = new EngineInstances();
    }

    public string? StcopEnginePath {
        get => _instances.StcopEnginePath;
        set => SetProperty(_instances.StcopEnginePath, value, _instances,
            (i, p) => i.StcopEnginePath = p);
    }

    public string? StcopAssetsPath {
        get => _instances.StcopAssetsPath;
        set => SetProperty(_instances.StcopAssetsPath, value, _instances,
            (i, p) => i.StcopAssetsPath = p);
    }

    public string? StcsEnginePath {
        get => _instances.StcsEnginePath;
        set => SetProperty(_instances.StcsEnginePath, value, _instances,
            (i, p) => i.StcsEnginePath = p);
    }

    public string? StcsAssetsPath {
        get => _instances.StcsAssetsPath;
        set => SetProperty(_instances.StcsAssetsPath, value, _instances,
            (i, p) => i.StcsAssetsPath = p);
    }

    public string? StsocEnginePath {
        get => _instances.StsocEnginePath;
        set => SetProperty(_instances.StsocEnginePath, value, _instances,
            (i, p) => i.StsocEnginePath = p);
    }

    public string? StsocAssetsPath {
        get => _instances.StsocAssetsPath;
        set => SetProperty(_instances.StsocAssetsPath, value, _instances,
            (i, p) => i.StsocAssetsPath = p);
    }
}
