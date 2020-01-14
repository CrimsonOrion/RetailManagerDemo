using Caliburn.Micro;

using RMDesktop.UI.EventModels;

namespace RMDesktop.UI.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly SalesViewModel _salesVM;

        public ShellViewModel(SalesViewModel salesVM, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _salesVM = salesVM;
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public void Handle(LogOnEvent message) => ActivateItem(_salesVM);
    }
}