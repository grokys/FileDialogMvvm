using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FileDialogMvvm.ViewModels;
using ReactiveUI;

namespace FileDialogMvvm.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            // When the window is activated, registers a handler for the ShowOpenFileDialog interaction.
            this.WhenActivated(d => d(ViewModel.ShowOpenFileDialog.RegisterHandler(ShowOpenFileDialog)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task ShowOpenFileDialog(InteractionContext<Unit, string?> interaction)
        {
            var dialog = new OpenFileDialog();
            var fileNames = await dialog.ShowAsync(this);
            interaction.SetOutput(fileNames.FirstOrDefault());
        }
    }
}
