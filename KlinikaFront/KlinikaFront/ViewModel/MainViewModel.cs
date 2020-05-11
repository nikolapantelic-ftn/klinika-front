using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class MainViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToIndex;
        private ICommand _toggleMenu;
        private ICommand _goToLogin;
        private ICommand _goToScheduleExamination;
        private ICommand _goToExaminations;
        public bool MenuOpened { get; set; } = false;

        public ICommand GoToIndex
        {
            get
            {
                return _goToIndex ?? (_goToIndex = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToIndexScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand ToggleMenu
        {
            get
            {
                return _toggleMenu ?? (_toggleMenu = new RelayCommand(x =>
                {
                    Mediator.Notify("ToggleMenu", "");
                }));
            } 
        }

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToScheduleExamination
        {
            get
            {
                return _goToScheduleExamination ?? (_goToScheduleExamination = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToScheduleExaminationScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        public ICommand GoToExaminations
        {
            get
            {
                return _goToExaminations ?? (_goToExaminations = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToExaminationsScreen", "");
                    MenuOpened = false;
                }));
            }
        }

        private void OnToggleMenu(object obj)
        {
            MenuOpened = !MenuOpened;
            OnPropertyChanged("MenuOpened");
        }

        public MainViewModel()
        {
            Mediator.Subscribe("ToggleMenu", OnToggleMenu);
        }

    }
}
