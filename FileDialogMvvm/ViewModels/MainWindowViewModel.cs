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
            // The OpenFile command is bound to a button/menu item in the UI.
            OpenFile = ReactiveCommand.CreateFromTask(OpenFileAsync);

            // The ShowOpenFileDialog interaction requests the UI to show the file open dialog.
            ShowOpenFileDialog = new Interaction<Unit, string?>();
        }

        public ReactiveCommand<Unit, Unit> OpenFile { get; }
        public Interaction<Unit, string?> ShowOpenFileDialog { get; }

        private async Task OpenFileAsync()
        {
            var fileName = await ShowOpenFileDialog.Handle(Unit.Default);

            if (fileName is object)
            {
                // Put your logic for opening file here.
            }
        }
    }
}
