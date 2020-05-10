using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlinikaFront.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IPageViewModel>();
                }
                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
            {
                PageViewModels.Add(viewModel);
            }
            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }

        private void OnGoToIndexScreen(object obj)
        {
            ChangeViewModel(PageViewModels[0]);
        }

        private void OnGoToLoginScreen(object obj)
        {
            ChangeViewModel(PageViewModels[2]);
        }

        private void OnLogin(object obj)
        {
            //TO-DO: Logging in
            ChangeViewModel(PageViewModels[1]);
        }

        public MainWindowViewModel()
        {
            PageViewModels.Add(new IndexViewModel());
            PageViewModels.Add(new MainViewModel());
            PageViewModels.Add(new LoginViewModel());

            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("GoToIndexScreen", OnGoToIndexScreen);
            Mediator.Subscribe("GoToLoginScreen", OnGoToLoginScreen);
            Mediator.Subscribe("Login", OnLogin);
        }
    }
}
