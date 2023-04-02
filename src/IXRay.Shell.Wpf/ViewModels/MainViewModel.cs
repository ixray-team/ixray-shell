using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

using ImeSense.Helpers.Mvvm.ComponentModel;
using ImeSense.Helpers.Mvvm.Input;

using IXRay.Shell.Wpf.Views;

namespace IXRay.Shell.Wpf.ViewModels;

public class MainViewModel : ObservableObject {
    private IRelayCommand? _exitCommand;
    private IRelayCommand? _switchCommonCommand;
    private IRelayCommand? _switchDeveloperCommand;
    private IRelayCommand? _switchModmakerCommand;

    public ObservableCollection<UserControl> ContentCollection { get; private set; }

    public MainViewModel() {
        ContentCollection = new ObservableCollection<UserControl> { new CommonUserControl() };
    }

    public IRelayCommand ExitCommand => _exitCommand ??= new RelayCommand(Exit);
    public IRelayCommand SwitchCommonCommand => _switchCommonCommand ??= new RelayCommand(SwitchCommon);
    public IRelayCommand SwitchDeveloperCommand => _switchDeveloperCommand ??= new RelayCommand(SwitchDeveloper);
    public IRelayCommand SwitchModmakerCommand => _switchModmakerCommand ??= new RelayCommand(SwitchModmaker);

    private void Exit() => Application.Current.Shutdown();

    private void SwitchCommon() {
        if (ContentCollection.Count != 0) {
            ContentCollection.Clear();
        }
        ContentCollection.Add(new CommonUserControl());
    }

    private void SwitchDeveloper() {
        if (ContentCollection.Count != 0) {
            ContentCollection.Clear();
        }
        ContentCollection.Add(new DeveloperUserControl());
    }

    private void SwitchModmaker() {
        if (ContentCollection.Count != 0) {
            ContentCollection.Clear();
        }
        ContentCollection.Add(new ModmakerUserControl());
    }
}
