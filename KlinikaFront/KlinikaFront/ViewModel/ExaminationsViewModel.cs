using KlinikaFront.Utilities;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class ExaminationsViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;

        public ICommand GoToPrevious
        {
            get
            {
                return _goToPrevious ?? (_goToPrevious = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToPreviousScreen", "");
                }));
            }
        }
    }
}
