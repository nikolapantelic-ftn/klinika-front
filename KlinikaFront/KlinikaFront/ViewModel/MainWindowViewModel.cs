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
        private IPageViewModel PreviousPageViewModel { get; set; }
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
            PreviousPageViewModel = CurrentPageViewModel;
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

        private void OnGoToScheduleExaminationScreen(object obj)
        {
            ChangeViewModel(PageViewModels[3]);
        }

        private void OnGoToExaminationsScreen(object obj)
        {
            ChangeViewModel(PageViewModels[4]);
        }

        private void OnLogin(object obj)
        {
            //TO-DO: Logging in
            ChangeViewModel(PageViewModels[1]);
        }

        private void OnGoToPreviousScreen(object obj)
        {
            ChangeViewModel(PreviousPageViewModel);
        }

        public MainWindowViewModel()
        {
            PageViewModels.Add(new IndexViewModel());
            PageViewModels.Add(new MainViewModel());
            PageViewModels.Add(new LoginViewModel());
            PageViewModels.Add(new ScheduleExaminationViewModel());
            PageViewModels.Add(new ExaminationsViewModel());

            CurrentPageViewModel = PageViewModels[0];

            Mediator.Subscribe("GoToIndexScreen", OnGoToIndexScreen);
            Mediator.Subscribe("GoToLoginScreen", OnGoToLoginScreen);
            Mediator.Subscribe("GoToPreviousScreen", OnGoToPreviousScreen);
            Mediator.Subscribe("GoToScheduleExaminationScreen", OnGoToScheduleExaminationScreen);
            Mediator.Subscribe("GoToExaminationsScreen", OnGoToExaminationsScreen);
            Mediator.Subscribe("Login", OnLogin);

        }
    }
}
