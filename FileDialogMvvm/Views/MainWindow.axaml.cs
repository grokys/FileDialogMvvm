using System.Threading.Tasks;
using Avalonia;
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
            this.WhenActivated(d => d(ViewModel.ShowDialog.RegisterHandler(ShowDialog)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task ShowDialog(InteractionContext<DialogViewModel, string?> interaction)
        {
            var dialog = new DialogWindow();
            dialog.DataContext = interaction.Input;
            
            var result = await dialog.ShowDialog<string?>(this);
            interaction.SetOutput(result);
        }
    }
}
