using System;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using FileDialogMvvm.ViewModels;
using ReactiveUI;

namespace FileDialogMvvm.Views
{
    public class DialogWindow : ReactiveWindow<DialogViewModel>
    {
        public DialogWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel.Ok.Subscribe(_ => Close(ViewModel.Text))));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
