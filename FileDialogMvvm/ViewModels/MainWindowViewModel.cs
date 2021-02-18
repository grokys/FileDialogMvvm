using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

namespace FileDialogMvvm.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            // The OpenDialog command is bound to a button/menu item in the UI.
            OpenDialog = ReactiveCommand.CreateFromTask(OpenDialogAsync);

            // The ShowDialog interaction requests the UI to show the dialog.
            ShowDialog = new Interaction<DialogViewModel, string?>();
        }

        public ReactiveCommand<Unit, Unit> OpenDialog { get; }
        public Interaction<DialogViewModel, string?> ShowDialog { get; }

        private async Task OpenDialogAsync()
        {
            var vm = new DialogViewModel { Text = "Hello Dialog!" };
            var result = await ShowDialog.Handle(vm);

            if (result is object)
            {
                // Here's the result.
            }
        }
    }
}
