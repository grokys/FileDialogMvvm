using System.Reactive;
using ReactiveUI;

namespace FileDialogMvvm.ViewModels
{
    public class DialogViewModel
    {
        public DialogViewModel()
        {
            Ok = ReactiveCommand.Create(() => { });
        }

        public string? Text { get; set; }
        public ReactiveCommand<Unit, Unit> Ok { get; }
    }
}
