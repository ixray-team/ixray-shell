using System.IO;
using System.Windows;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

using IXRay.Shell.Wpf.Models;

using static IXRay.Shell.Wpf.Models.DragAndDrop;
using static IXRay.Shell.Wpf.Models.Launcher;

namespace IXRay.Shell.Wpf.ViewModels;

public class CommonViewModel : ObservableObject {
    private readonly EngineInstances _instances;

    private IRelayCommand<object>? _previewDragOverCommand;

    private IRelayCommand<object>? _dropStcopEngineCommand;
    private IRelayCommand<object>? _dropStcopAssetsCommand;

    private IRelayCommand<object>? _dropStcsEngineCommand;
    private IRelayCommand<object>? _dropStcsAssetsCommand;

    private IRelayCommand<object>? _dropStsocEngineCommand;
    private IRelayCommand<object>? _dropStsocAssetsCommand;

    private IRelayCommand? _specityStcopEnginePathCommand;
    private IRelayCommand? _specityStcopAssetsPathCommand;
    private IRelayCommand? _launchStcopEngineCommand;

    private IRelayCommand? _specityStcsEnginePathCommand;
    private IRelayCommand? _specityStcsAssetsPathCommand;
    private IRelayCommand? _launchStcsEngineCommand;

    private IRelayCommand? _specityStsocEnginePathCommand;
    private IRelayCommand? _specityStsocAssetsPathCommand;
    private IRelayCommand? _launchStsocEngineCommand;

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

    private void DropStcopEngineHandler(DragEventArgs? e) =>
        StcopEnginePath = DropFileHander(e, "xrEngine.exe");

    private void DropStcopAssetsHandler(DragEventArgs? e) =>
        StcopAssetsPath = DropFolderHander(e);

    private void DropStcsEngineHandler(DragEventArgs? e) =>
        StcsEnginePath = DropFileHander(e, "xrEngine.exe");

    private void DropStcsAssetsHandler(DragEventArgs? e) =>
        StcsAssetsPath = DropFolderHander(e);

    private void DropStsocEngineHandler(DragEventArgs? e) =>
        StsocEnginePath = DropFileHander(e, "XR_3DA.exe");

    private void DropStsocAssetsHandler(DragEventArgs? e) =>
        StsocAssetsPath = DropFolderHander(e);

    private void SpecityStcopEnginePath() =>
        StcopEnginePath = GetExecutablePath("X-Ray Engine|xrEngine.exe", StcopEnginePath);

    private void SpecityStcopAssetsPath() =>
        StcopAssetsPath = GetFolderPath(StcopAssetsPath);

    private void LaunchStcopEngine() =>
        Launch(StcopEnginePath, StcopAssetsPath);

    private void SpecityStcsEnginePath() =>
        StcsEnginePath = GetExecutablePath("X-Ray Engine|xrEngine.exe", StcsEnginePath);

    private void SpecityStcsAssetsPath() =>
        StcsAssetsPath = GetFolderPath(StcopAssetsPath);

    private void LaunchStcsEngine() =>
        Launch(StcsEnginePath, StcsAssetsPath);

    private void SpecityStsocEnginePath() =>
        StsocEnginePath = GetExecutablePath("X-Ray Engine|XR_3DA.exe", StsocEnginePath);

    private void SpecityStsocAssetsPath() =>
        StsocAssetsPath = GetFolderPath(StcopAssetsPath);

    private void LaunchStsocEngine() =>
        Launch(StsocEnginePath, StsocAssetsPath);

    public IRelayCommand<object> PreviewDragOverCommand => _previewDragOverCommand ??= new RelayCommand<object>(
        e => PreviewDragOverHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStcopEngineCommand => _dropStcopEngineCommand ??= new RelayCommand<object>(
        e => DropStcopEngineHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStcopAssetsCommand => _dropStcopAssetsCommand ??= new RelayCommand<object>(
        e => DropStcopAssetsHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStcsEngineCommand => _dropStcsEngineCommand ??= new RelayCommand<object>(
        e => DropStcsEngineHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStcsAssetsCommand => _dropStcsAssetsCommand ??= new RelayCommand<object>(
        e => DropStcsAssetsHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStsocEngineCommand => _dropStsocEngineCommand ??= new RelayCommand<object>(
        e => DropStsocEngineHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand<object> DropStsocAssetsCommand => _dropStsocAssetsCommand ??= new RelayCommand<object>(
        e => DropStsocAssetsHandler(e as DragEventArgs),
        p => true);

    public IRelayCommand SpecityStcopEnginePathCommand =>
        _specityStcopEnginePathCommand ??= new RelayCommand(SpecityStcopEnginePath);
    public IRelayCommand SpecityStcopAssetsPathCommand =>
        _specityStcopAssetsPathCommand ??= new RelayCommand(SpecityStcopAssetsPath);
    public IRelayCommand LaunchStcopEngineCommand =>
        _launchStcopEngineCommand ??= new RelayCommand(LaunchStcopEngine);

    public IRelayCommand SpecityStcsEnginePathCommand =>
        _specityStcsEnginePathCommand ??= new RelayCommand(SpecityStcsEnginePath);
    public IRelayCommand SpecityStcsAssetsPathCommand =>
        _specityStcsAssetsPathCommand ??= new RelayCommand(SpecityStcsAssetsPath);
    public IRelayCommand LaunchStcsEngineCommand =>
        _launchStcsEngineCommand ??= new RelayCommand(LaunchStcsEngine);

    public IRelayCommand SpecityStsocEnginePathCommand =>
        _specityStsocEnginePathCommand ??= new RelayCommand(SpecityStsocEnginePath);
    public IRelayCommand SpecityStsocAssetsPathCommand =>
        _specityStsocAssetsPathCommand ??= new RelayCommand(SpecityStsocAssetsPath);
    public IRelayCommand LaunchStsocEngineCommand =>
        _launchStsocEngineCommand ??= new RelayCommand(LaunchStsocEngine);
}
