using Caliburn.Micro;

using RMDesktop.UI.ViewModels;

using System.Windows;

namespace RMDesktop.UI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper() => Initialize();

        protected override void OnStartup(object sender, StartupEventArgs e) => DisplayRootViewFor<ShellViewModel>();
    }
}