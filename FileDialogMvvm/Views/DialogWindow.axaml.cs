using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FileDialogMvvm.ViewModels;

namespace FileDialogMvvm.Views
{
    public class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void OkClick(object? sender, RoutedEventArgs e)
        {
            // This could also be handled by a command/interaction but putting it in an event handler
            // for simplicity.
            var vm = (DialogViewModel)DataContext!;
            Close("Result was " + vm.Text);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
