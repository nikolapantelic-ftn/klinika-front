using KlinikaFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlinikaFront.ViewModel
{
    class Registration1ViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToNextRegistration;
        private ICommand _goToLogin;

        public ICommand GoToNextRegistration
        {
            get
            {
                return _goToNextRegistration ?? (_goToNextRegistration = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToNextRegistrationScreen", "");
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
                }));
            }
        }
    }
    class Registration2ViewModel: BaseViewModel, IPageViewModel
    {
        private ICommand _goToPrevious;
        private ICommand _goToLogin;
        private ICommand _register;

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

        public ICommand GoToLogin
        {
            get
            {
                return _goToLogin ?? (_goToLogin = new RelayCommand(x =>
                {
                    Mediator.Notify("GoToLoginScreen", "");
                }));
            }
        }

        public ICommand Register
        {
            get
            {
                return _register ?? (_register = new RelayCommand(x =>
                {
                    Mediator.Notify("Register", "");
                }));
            }
        }
    }
}
